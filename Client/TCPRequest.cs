using System;
using System.IO;
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
        public string message;
        
        /// <summary>
        /// Метод реализующий отправку запроса на сервер
        /// </summary>
        /// <param name="tcpSocket"></param>
        /// <param name="tcpEndPoint"></param>
        public void SendRequestToServer(Socket tcpSocket, IPEndPoint tcpEndPoint)
        {
            Console.WriteLine("Введите путь до файла:");
            message = Console.ReadLine();
            StreamReader sr = null;
            bool isCreate = true;
            try
            {
                sr = new StreamReader(message, Encoding.Default);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден: {0}", message);
                isCreate = false;
            }

            if (isCreate)
            {
                string line;
                line = sr.ReadLine();
                Console.WriteLine(line);
                var data = Encoding.UTF8.GetBytes(line);
                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);
            }
        }
    }
}