using MSock.Server.Sockets;
using System;

namespace MSock.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 5555;
            Console.WriteLine(string.Format("Server Başlatıldı. Port: {0}", port));
            Console.WriteLine("-----------------------------");

            Listener listener = new Listener(port, 50);

            listener.Start();

            Console.ReadLine();
        }
    }
}
