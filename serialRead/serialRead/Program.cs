
 //FILE          : Program.cs
 //PROJECT       : IAd - Final Project
 //PROGRAMMER    : Bowen Zhuang, Linyan Li, Kevin Li
 //FIRST VERSION : 2015-04-13
 //DESCRIPTION   : This file implements the light detection project. It connects to the 
 //               Arduino borad which have a LED light and a light sensor. The light senor 
 //               detect the ambiance light level which will be used to adjust the LED 
 //               brightness. This program also sends the data to the server to store in
 //              database using TCP/IP protocol.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Timers;

namespace serialRead_client
{
    
      //NAME     :   Program
      //PURPOSE  :   This class will be the connection to the Arduino board, and the connection
      //             to the server. Also it receives from the board and send to server.
     
    class Program
    {
        private static Timer aTimer;
        private static SerialPort mySerialPort;
        private static NetworkStream stream;
        private static TcpClient client;

        
          //NAME     :   Main
          //PURPOSE  :   This function will be the connection to the Arduino board, and the connection
          //             to the server.
         
        static int Main(string[] args)
        {
            //if (args.Length != 2){
            //    Console.WriteLine("Usage: serialRead serverIP serverPort");
            //    return -1;
            //}


            try{
               // InitializeComponent(args[0],Convert.ToInt32(args[1]));
                InitializeComponent("127.0.0.1", 1231);
                Console.WriteLine("Press any key to disconnect...");
                Console.WriteLine();
                Console.ReadKey();
                mySerialPort.Close();
                stream.Close();
                client.Close();

            }catch{
                Console.WriteLine("error");
                return -1;
            }
            
            return 0;
        }


          //NAME     :   OnTimedEvent
          //PURPOSE  :   This function retrive the light level from the board and display them
          //             It uses timer instead of sp.DataReceived handler, hence complete msg 
          //             can be received
         
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
           // first number is sensor readding range 0~900
            // second number is led voltage, range 0~255
            string indata = mySerialPort.ReadExisting();

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(indata);

            // Get a client stream for reading and writing. 
            //  Stream stream = client.GetStream();

            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", indata);

           // mySerialPort.DiscardInBuffer();
          //  mySerialPort.DiscardOutBuffer();
              
        }


        //NAME     :   InitializeComponent
        //PURPOSE  :   This function send the data to the server

        private static void InitializeComponent(string server, Int32 port)
        {
            mySerialPort = new SerialPort("COM3");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.NewLine = @"\r\n";
            mySerialPort.Open();

            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;

            try
            {
                // Create a TcpClient. 
                // Note, for this client to work you need to have a TcpServer  
                // connected to the same address as specified by the server, port 
                // combination.
                client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                // Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing. 
                //  Stream stream = client.GetStream();

                stream = client.GetStream();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }



    }
}
