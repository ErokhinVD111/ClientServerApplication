namespace Server
{
    public class Server
    {
        public TCPConnector TcpConnector { get; set; }
        public TCPListener TcpListener { get; set; }

        public Server()
        {
            TcpConnector = new TCPConnector();
            TcpListener = new TCPListener();
        }

        public void Run()
        {
            TcpListener.Listen(TcpConnector.tcpSocket);
        }
    }
}