using System;
using System.Net;
using System.Net.Sockets;

namespace TCP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("simple server");

            try
            {
                var port = 13000;
                var localAddress = IPAddress.Parse("127.0.0.1");
                var server = new TcpListener(localAddress, port);
                server.Start();
                String text = "<h1>It's my server!!!</h1>";
                String message = $"HTTP/1.0 200 OK\nServer: {server.LocalEndpoint}\nConnection: close\nContent-Length: {text.Length}\nContent-Type: text/html\n\n{text}";

                Byte[] responseArray = System.Text.Encoding.ASCII.GetBytes(message);

                var bytes = new byte[256];
                while (true)
                {
                    Console.WriteLine("waiting to connection");
                    var client = server.AcceptTcpClient();
                    Console.WriteLine($"Accepted connection from {client.Client.RemoteEndPoint}");
                    NetworkStream stream = client.GetStream();

                    stream.Write(responseArray, 0, responseArray.Length);
                    Console.WriteLine($"Sent: {message}");
                    Console.WriteLine();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
