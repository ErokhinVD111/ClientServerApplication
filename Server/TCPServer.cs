namespace Server
{
    /// <summary>
    /// Класс реализующий серверную часть
    /// </summary>
    public class TCPServer
    {
        public TCPConnector TcpConnector { get; set; }
        public TCPListener TcpListener { get; set; }

        public TCPServer()
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