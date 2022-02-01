using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Processing
{
    /// <summary>
    /// Интерфейс типа обработки
    /// </summary>
    public interface ITypeProcessing
    {
        /// <summary>
        /// Метод для запуска обработки
        /// </summary>
        public void Run();
        
        /// <summary>
        /// Метод для запуска обработки согласно пришедшим данным от клиента
        /// </summary>
        /// <param name="dataFromClient"></param>
        /// <returns></returns>
        public bool Run(string dataFromClient);
    }
}