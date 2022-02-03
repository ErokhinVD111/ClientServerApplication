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
        public StringBuilder answer = new StringBuilder();
        /// <summary>
        /// Метод для принятия и обработки ответа от сервера
        /// </summary>
        /// <param name="tcpSocket"></param>
        public void AcceptAnswerFromServer(Socket tcpSocket, string path, IteratorFiles iterator)
        {
            var buffer = new byte[256];
            int size;
            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            } while (tcpSocket.Available > 0);
            PrintAnswer(answer, path, iterator);
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
        }
        /// <summary>
        /// Метод для вывода на консоль ответа от сервера
        /// </summary>
        /// <param name="answerFromServer"></param>
        public void PrintAnswer(StringBuilder answerFromServer, string path, IteratorFiles iterator)
        {
            if (!answerFromServer.Equals("Большое количество запросов! Подождите."))
            {
                Console.WriteLine("Ответ от сервера: {0} - {1}", path, answerFromServer);
                
            }
            else
            {
                Console.WriteLine("Ответ от сервера: {0}", answerFromServer);
            }
        }
    }
}