using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                TCPConnector connector = new TCPConnector();
                TCPRequest request = new TCPRequest();
                TCPAcceptor acceptor = new TCPAcceptor();

                request.SendRequestToServer(connector.tcpSocket, connector.tcpEndPoint);
                acceptor.AcceptAnswerFromServer(connector.tcpSocket);
            }
        }
    }
}