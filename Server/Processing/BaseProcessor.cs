using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Processing
{
    /// <summary>
    /// Базовый класс обработчик
    /// </summary>
    public abstract class BaseProcessor 
    {
        public static int _requestMaxCounter;
        protected StringBuilder _dataFromClient;
        protected ITypeProcessing _typeProcessing;

        public BaseProcessor(ITypeProcessing typeProcessing, StringBuilder dataFromClient, int requestMaxCounter)
        {
            _typeProcessing = typeProcessing;
            _dataFromClient = dataFromClient;
            _requestMaxCounter = requestMaxCounter;
        }
        
        /// <summary>
        /// Метод для асинхронной обработки данных из пришедшего запроса
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public async Task ProcessingAsync(Socket listener, RequestCounter requestCounter)
        {
            requestCounter.requestCount++;
            await Task.Run(() => Processing(listener));
            requestCounter.requestCount--;
        }

        /// <summary>
        /// Метод для обработки данных из пришедшего запроса
        /// </summary>
        protected virtual void Processing(Socket listener)
        {
            _typeProcessing.Run();
            EndConnection(listener);
        }
        
        /// <summary>
        /// Метод завершения соединения
        /// </summary>
        /// <param name="listener"></param>
        protected virtual void EndConnection(Socket listener)
        {
            listener.Send(Encoding.UTF8.GetBytes("Successful!"));
            listener.Shutdown(SocketShutdown.Both);
            listener.Close();

        }
        
    }
}