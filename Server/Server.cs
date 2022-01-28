namespace Server
{
    /// <summary>
    /// Класс реализующий серверную часть
    /// </summary>
    public class Server
    {
        public TCPConnector TcpConnector { get; set; }
        public TCPListener TcpListener { get; set; }

        public Server()
        {
            TcpConnector = new TCPConnector();
            TcpListener = new TCPListener();
        }
        /// <summary>
        /// Метод для запуска сервера
        /// </summary>
        public void Run()
        {
            TcpListener.Listen(TcpConnector.tcpSocket);
        }
    }
}