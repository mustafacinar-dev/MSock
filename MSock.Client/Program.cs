using MSock.Client.Sockets;
using MSock.DataTransferObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MSock.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 5555;
            Console.WriteLine(string.Format("Client Başlatıldı. Port: {0}", port));
            Console.WriteLine("-----------------------------");

            TcpSocket tcpSocket = new TcpSocket(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
            tcpSocket.Start();

            Console.WriteLine("Göndermek için \"S\", basınız...");

            int count = 1;
            while (Console.ReadLine().ToUpper() == "S")
            {
                DataTransferObject dataTransferObject = new DataTransferObject()
                {
                    Status = string.Format("{0}. Alındı", count),
                    Message = string.Format("{0} ip numaralı client üzerinden geliyorum!", GetLocalIPAddress())
                };

                tcpSocket.SendData(dataTransferObject);
                count++;
            }

            Console.ReadLine();
        }

        static string GetLocalIPAddress()
        {
            string localIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();

            return localIP;
        }
    }
}
