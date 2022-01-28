using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Класс для максимального кол-ва запросов
    /// </summary>
    public class CountRequest
    {
        /// <summary>
        /// Счетчик запросов
        /// </summary>
        public int countRequst;
        /// <summary>
        /// Максимальное кол-во запросов
        /// </summary>
        public int maxCountRequest;

        public CountRequest()
        {
            countRequst = 0;
            maxCountRequest = 6;
        }
    }
    /// <summary>
    /// Класс для прослушивания сокета на приход запроса
    /// </summary>
    public class TCPListener
    {
        private CountRequest _countRequest = new CountRequest();
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

                if (_countRequest.countRequst < _countRequest.maxCountRequest)
                    Processing(data, listener);
                else
                {
                    listener.Send(Encoding.UTF8.GetBytes("Bad request!" + 
                                                         $" Count of request is {_countRequest.maxCountRequest}!" 
                                                         + " Wait please."));
                    listener.Shutdown(SocketShutdown.Both);
                    listener.Close();
                }
            }
        }
        /// <summary>
        /// Метод для асинхронной обработки данных из пришедшего запроса
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listener"></param>
        /// <returns></returns>
        public async Task Processing(StringBuilder data, Socket listener)
        {
            _countRequest.countRequst++;
            await Task.Run(() => SomeMethodForProccessing(data));
            await Task.Run(() => EndConnection(data, listener));
            _countRequest.countRequst--;
        }
        /// <summary>
        /// Метод для обработки данных из пришедшего запроса
        /// </summary>
        /// <param name="data"></param>
        public void SomeMethodForProccessing(StringBuilder data)
        {
            Random random = new Random();
            Thread.Sleep(1000 * random.Next(5, 10));
            Console.WriteLine(data);
        }
        /// <summary>
        /// Метод завершения соединения
        /// </summary>
        /// <param name="str"></param>
        /// <param name="listener"></param>
        public void EndConnection(StringBuilder str, Socket listener)
        {
            listener.Send(Encoding.UTF8.GetBytes("Successful!" + 
                                                 $" Count of request:{_countRequest.countRequst}"
                                                 + "Message:" + str));
            listener.Shutdown(SocketShutdown.Both);
            listener.Close();

        }
    }
}