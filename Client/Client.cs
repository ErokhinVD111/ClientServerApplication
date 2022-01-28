namespace Client
{
    public class Client
    {
        public TCPConnector TcpConnector { get; set; }
        public TCPAcceptor TcpAcceptor { get; set; }
        public TCPRequest TcpRequest { get; set; }

        public Client()
        {
            TcpConnector = new TCPConnector();
            TcpAcceptor = new TCPAcceptor();
            TcpRequest = new TCPRequest();
        }

        public void SendRequest()
        {
            TcpRequest.SendRequestToServer(TcpConnector.tcpSocket, TcpConnector.tcpEndPoint); 
        }

        public void AcceptAnswer()
        {
            TcpAcceptor.AcceptAnswerFromServer(TcpConnector.tcpSocket);
        }
    }
}