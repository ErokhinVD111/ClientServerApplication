using System;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class TCPAcceptor
    {
        StringBuilder answer = new StringBuilder();
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

        public void PrintAnswer(StringBuilder message)
        {
            Console.WriteLine("Answer from server: {0}", message);
        }
    }
}