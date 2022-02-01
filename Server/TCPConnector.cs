using System.Net;
using System.Net.Sockets;
using Connection;

namespace Server
{
    /// <summary>
    /// Класс для подключения сервера по протоколу TCP
    /// </summary>
    public class TCPConnector : BaseConnector
    {
        public TCPConnector()
        {
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);
        }
    }
}