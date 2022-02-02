using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServer tcpServer = new TCPServer();
            tcpServer.Run();
        }
    }
}