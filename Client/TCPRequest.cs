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
        // public string path;
        // public int _iteratorFiles;
        // public string[] _allfiles;

        /// <summary>
        /// Метод реализующий отправку запроса на сервер
        /// </summary>
        /// <param name="tcpSocket"></param>
        /// <param name="tcpEndPoint"></param>
        public void SendRequestAsync(Socket tcpSocket, IPEndPoint tcpEndPoint, IteratorFiles iteratorFiles,
            string[] _allfiles)
        {
            Console.WriteLine("Выберете файл:");
            iteratorFiles.Iterator = Convert.ToInt32(Console.ReadLine());
            StreamReader sr = new StreamReader(_allfiles[iteratorFiles.Iterator], Encoding.UTF8);
            string line = sr.ReadLine();
            sr.Close();
            // Console.WriteLine(_allfiles[iteratorFiles.Iterator]);
            // Console.WriteLine(line); 
            var data = Encoding.UTF8.GetBytes(line);
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);


            #region comments

            //sr = new StreamReader(_allfiles[iteratorFiles.Iterator], Encoding.Default);
            //string line = sr.ReadLine();
            //sr.Close();
            // Console.WriteLine(_allfiles[iteratorFiles.Iterator]);
            // Console.WriteLine(line);
            // var data = Encoding.UTF8.GetBytes(line);
            // tcpSocket.Connect(tcpEndPoint);
            // tcpSocket.Send(data);

            #endregion
        }
    }
}