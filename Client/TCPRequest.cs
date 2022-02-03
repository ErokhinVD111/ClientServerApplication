using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="iteratorFiles"></param>
        /// <param name="files"></param>
        public void SendRequest(Socket tcpSocket, IPEndPoint tcpEndPoint, IteratorFiles iteratorFiles,
            string[] files)
        {
            Console.WriteLine("Выберите файл:");
            iteratorFiles.Iterator = Convert.ToInt32(Console.ReadLine());
            StreamReader sr = new StreamReader(files[iteratorFiles.Iterator], Encoding.UTF8);
            string line = sr.ReadLine();
            sr.Close();
            var data = Encoding.UTF8.GetBytes(line);
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);
        }
    }
}
