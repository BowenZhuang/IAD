using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using serialRead_server;
using System.Net;
using System.IO;


namespace serialRead_server
{
    class Program
    {
        private static TcpListener server = null;  

        static void Main(string[] args)
        {
            server = new TcpListener(IPAddress.Loopback, 1230);

            server.Start();
            TcpClient client = server.AcceptTcpClient();
            NetworkStream strm = client.GetStream();


            try
            {
                IFormatter formatter = new BinaryFormatter();

                //MemoryStream dataCopy = new MemoryStream();
                //using (var clientRequestStream = client.GetStream())
                //{
                //    clientRequestStream.CopyTo(dataCopy);
                //}
                //dataCopy.Position = 0;
                //var requestHeader = dataCopy.GetUtf8String();

                ////Person p = (Person)formatter.Deserialize(strm); // you have to cast the deserialized object 
                //strm.Seek(0, System.IO.SeekOrigin.Begin);
                LightControlRead read = (LightControlRead)formatter.Deserialize(strm);

                // Console.WriteLine("Hi, I'm " + p.FirstName + " " + p.LastName + " and I'm " + p.age + " years old!");

            }
            catch
            {
                Console.WriteLine("error");
            }

            strm.Close();
            client.Close();
            server.Stop(); 
        }
    }
}
