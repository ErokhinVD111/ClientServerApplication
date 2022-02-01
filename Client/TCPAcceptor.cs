using System;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    /// <summary>
    /// Класс для принятия ответа от сервера
    /// </summary>
    public class TCPAcceptor
    {
        /// <summary>
        /// После для ответа от сервера
        /// </summary>
        private StringBuilder answer = new StringBuilder();
        /// <summary>
        /// Метод для принятия и обработки ответа от сервера
        /// </summary>
        /// <param name="tcpSocket"></param>
        public void AcceptAnswerFromServer(Socket tcpSocket)
        {
            var buffer = new byte[256];
            int size;
            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            } while (tcpSocket.Available > 0);
            PrintAnswer(answer);
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
        }
        /// <summary>
        /// Метод для вывода на консоль ответа от сервера
        /// </summary>
        /// <param name="message"></param>
        public void PrintAnswer(StringBuilder message)
        {
            Console.WriteLine("Ответ от сервера: {0}", message);
        }
    }
}