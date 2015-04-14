
 //FILE          : Program.cs
 //PROJECT       : IAd - Final Project
 //PROGRAMMER    : Bowen Zhuang, Linyan Li, Kevin Li
 //FIRST VERSION : 2015-04-13
 //DESCRIPTION   : This file implements as a tcp/ip server for the light detection program.
 //                And then store the light and the photo sensor data in to database.

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using LightControl_server;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;

namespace LightControl_server
{
    
      //NAME     :   Program
      //PURPOSE  :   This class contains the main function which starts the server for receiving the 
      //             light and photo sensor's data and store it into database.
     
    class Program
    {
        private static TcpListener server = null;
        private static Byte[] bytes = new Byte[1024];
        String data = null;

        
          //NAME     :   Main
          //PURPOSE  :   This class contains the main function which starts the server for receiving the 
          //             light and photo sensor's data and store it into database.
         
        static void Main(string[] args)
        {          
            server = new TcpListener(IPAddress.Loopback, 1231);
            Byte[] bytes = new Byte[1024];
            String data = null;
            string connectionString = "Server=localhost; Database=iad; Uid=root; Pwd=Conestoga1 ";;
            MySqlConnection connectoin = new MySqlConnection(connectionString);
               
            server.Start();
            Console.WriteLine("Waiting for connection...");
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected...");
            NetworkStream strm = client.GetStream();
            int i;


            // Loop to receive all the data sent by the client. 
            while ((i = strm.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);         

                try
                {
                    string[] output;
                    string[] strSeperators = new string[] { "\r\n" };
                    output = data.Split(strSeperators, StringSplitOptions.None);
                    

                    if (output.Length >= 2)
                    {
                     
                        int sensorRead = Convert.ToInt32(output[0]);
                        int ledRead = Convert.ToInt32(output[1]);
                        Console.WriteLine("");
                        Console.WriteLine("Received Data: ");
                        Console.WriteLine("Ambiance Light Leve {0} ", sensorRead);
                        Console.WriteLine("LED Brightness {0}", ledRead);

                        // Send to database                           
                        connectoin.Open();
                        Console.WriteLine("Connect to database...");
                        MySqlCommand command = connectoin.CreateCommand();
                        command.CommandText = "INSERT INTO lightControl(dateTime,ledRead,sensorRead) VALUES(@dateTime,@ledRead,@sensorRead)";
                        command.Parameters.AddWithValue("@dateTime", DateTime.Now);
                        command.Parameters.AddWithValue("@ledRead", sensorRead.ToString());
                        command.Parameters.AddWithValue("@sensorRead", ledRead.ToString());
                        command.ExecuteNonQuery();
                        connectoin.Close();
                        Console.WriteLine("Wrote to database...");
                      
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // Process the data sent by the client.
                //data = data.ToUpper();

                //byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                //// Send back a response.
                //strm.Write(msg, 0, msg.Length);
               // Console.WriteLine("Sent: {0}", data);
            }    
            strm.Close();
            client.Close();
            server.Stop();
        }
    }
}
