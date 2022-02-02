using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                TCPClient tcpClient = new TCPClient();
                tcpClient.SendRequest(); 
                tcpClient.AcceptAnswerAsync();
            }
        }
    }
}