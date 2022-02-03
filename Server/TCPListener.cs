using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.Processing;

namespace Server
{
    
    /// <summary>
    /// Класс для прослушивания сокета на приход запроса
    /// </summary>
    public class TCPListener
    {
        private RequestCounter _requestCounter;

        public TCPListener()
        {
            _requestCounter = new RequestCounter();
        }
        /// <summary>
        /// Метод реализующий прослушивание
        /// </summary>
        /// <param name="tcpSocket"></param>
        public void Listen(Socket tcpSocket)
        {
            while (true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[256];
                var data = new StringBuilder();
                int size;
                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } while (listener.Available > 0);
                var processor = new PalindromeProcessor(new Palindrome(), data, _requestCounter.requestMaxCount);
                if (_requestCounter.requestCount < _requestCounter.requestMaxCount)
                {
                    processor.ProcessingAsync(listener, _requestCounter);
                }
                else
                {
                    listener.Send(Encoding.UTF8.GetBytes("Большое количество запросов! Подождите."));
                    listener.Shutdown(SocketShutdown.Both);
                    listener.Close();
                }
            }
        }
        
    }
}