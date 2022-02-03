using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server.Processing
{
    /// <summary>
    /// Класс реализующий обработчик
    /// </summary>
    public class PalindromeProcessor : BaseProcessor
    {
        private bool isPalendrom;
        public PalindromeProcessor(ITypeProcessing typeProcessing, StringBuilder dataFromClient, int requestMaxCounter) :
            base(typeProcessing, dataFromClient, requestMaxCounter)
        {
            
        }

        protected override void Processing(Socket listener)
        {
            Random random = new Random();
            isPalendrom = _typeProcessing.Run(_dataFromClient.ToString());
            Thread.Sleep(1000 * random.Next(3, 6));
            EndConnection(listener);
        }

        protected override void EndConnection(Socket listener)
        {
            if (isPalendrom)
            {
                listener.Send(Encoding.UTF8.GetBytes($"палиндром"));
            }
            else
            {
                listener.Send(Encoding.UTF8.GetBytes($"не палиндром"));
            }

            listener.Shutdown(SocketShutdown.Both);
            listener.Close();
        }
    }
}