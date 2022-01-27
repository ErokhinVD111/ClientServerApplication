using System.Net;
using System.Net.Sockets;
using Connection;

namespace Server
{
    public class TCPConnector : ConnectionClientServer
    {
        public TCPConnector()
        {
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);
        }
    }
}