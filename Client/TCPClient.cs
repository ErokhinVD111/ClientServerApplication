using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Класс реализующий клиентскую часть
    /// </summary>
    public class TCPClient
    {
        public TCPConnector TcpConnector { get; set; }
        public TCPAcceptor TcpAcceptor { get; set; }
        public TCPRequest TcpRequest { get; set; }

        public TCPClient()
        {
            TcpConnector = new TCPConnector();
            TcpAcceptor = new TCPAcceptor();
            TcpRequest = new TCPRequest();
        }
        /// <summary>
        /// Метод для отправки запроса на сервер
        /// </summary>
        public void SendRequest()
        {
            TcpRequest.SendRequestToServer(TcpConnector.tcpSocket, TcpConnector.tcpEndPoint); 
        }
        /// <summary>
        /// Асинхронный метод для принятия ответа от сервера
        /// </summary>
        /// <returns></returns>
        public async Task AcceptAnswerAsync()
        {
            await Task.Run(() => AcceptAnswer());
        }
        /// <summary>
        /// Метод для принятия ответа от сервера
        /// </summary>
        public void AcceptAnswer()
        {
            TcpAcceptor.AcceptAnswerFromServer(TcpConnector.tcpSocket, TcpRequest.message);
        }
    }
}