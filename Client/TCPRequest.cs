using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class TCPRequest
    {
        public void SendRequestToServer(Socket tcpSocket, IPEndPoint tcpEndPoint)
        {
            Console.Write("Enter your message to server:");
            var message = Console.ReadLine();
            var data = Encoding.UTF8.GetBytes(message);
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);
        }
    }
}