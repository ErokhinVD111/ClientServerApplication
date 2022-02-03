using System;
using System.Diagnostics.CodeAnalysis;
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
        public string[] Files { get; set; }
        
        public IteratorFiles IteratorFiles;
        
        public TCPClient(string[] files, IteratorFiles iteratorFiles)
        {
            Files = files;
            IteratorFiles = iteratorFiles;
            TcpConnector = new TCPConnector();
            TcpAcceptor = new TCPAcceptor();
            TcpRequest = new TCPRequest();
        }
        
        /// <summary>
        /// Метод для отправки запроса на сервер
        /// </summary>
        public void SendRequest()
        {
            TcpRequest.SendRequest(TcpConnector.tcpSocket, TcpConnector.tcpEndPoint, IteratorFiles, Files);

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
            TcpAcceptor.AcceptAnswerFromServer(TcpConnector.tcpSocket, Files[IteratorFiles.Iterator]);
        }
    }
}