using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class TCPListener
    {
        public void Listen(Socket tcpSocket)
        {
            while (true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[256];
                int size;
                var data = new StringBuilder();
                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } while (listener.Available > 0);
                PrintData(data);
                listener.Send(Encoding.UTF8.GetBytes("Successful!"));
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }

        public void PrintData(StringBuilder data)
        {
            Random random = new Random();
            Thread.Sleep(1000 * random.Next(1, 6));
            Console.WriteLine(data);
        }
    }
}