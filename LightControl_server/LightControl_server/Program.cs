using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using LightControl_server;
using System.Net;
using System.IO;


namespace LightControl_server
{
    class Program
    {
        private static TcpListener server = null;
        private static Byte[] bytes = new Byte[1024];
        String data = null;

        static void Main(string[] args)
        {
            server = new TcpListener(IPAddress.Loopback, 1231);
            Byte[] bytes = new Byte[1024];
            String data = null;

            server.Start();
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected!");
            NetworkStream strm = client.GetStream();

            int i;

            // Loop to receive all the data sent by the client. 
            while ((i = strm.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data);


                try
                {

                    string[] output;
                    string[] strSeperators = new string[] { "\r\n" };

                    output = data.Split(strSeperators, StringSplitOptions.None);

                    if (output.Length >= 2)
                    {
                        try
                        {
                            int sensorRead = Convert.ToInt32(output[0]);
                            int ledRead = Convert.ToInt32(output[1]);


                            // Send to database
                        }
                        catch
                        {
                            Console.WriteLine("error");
                        }


                    }

                }
                catch
                {
                    Console.WriteLine("error");
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
