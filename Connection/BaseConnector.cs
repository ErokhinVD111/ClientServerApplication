using System.Net;
using System.Net.Sockets;

namespace Connection
{
    /// <summary>
    /// Базовый класс для подключения по протоколу TCP
    /// </summary>
    public abstract class BaseConnector
    {
        protected const string ip = "127.0.0.1";
        protected const int port = 8080;

        /// <summary>
        /// Точка входа
        /// </summary>
        public IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

        /// <summary>
        /// Сокет для подключения
        /// </summary>
        public Socket tcpSocket = new Socket
        (
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp
        );
    }
}