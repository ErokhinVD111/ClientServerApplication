using System.Net;
using System.Net.Sockets;

namespace Connection
{
    public abstract class ConnectionClientServer
    {
        protected const string ip = "127.0.0.1";
        protected const int port = 8080;
        public IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        public Socket tcpSocket = new Socket
        (
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp
        );
    }
}