using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPConnector connector = new TCPConnector();
            TCPListener listener = new TCPListener();
            listener.Listen(connector.tcpSocket);
        }
    }
}