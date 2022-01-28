using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    /// <summary>
    /// Класс для отправки запроса на сервер
    /// </summary>
    public class TCPRequest
    {
        /// <summary>
        /// Метод реализующий отправку запроса на сервер
        /// </summary>
        /// <param name="tcpSocket"></param>
        /// <param name="tcpEndPoint"></param>
        public void SendRequestToServer(Socket tcpSocket, IPEndPoint tcpEndPoint)
        {
            Console.WriteLine("Enter your message to server:");
            var message = Console.ReadLine();
            var data = Encoding.UTF8.GetBytes(message);
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);
        }
    }
}