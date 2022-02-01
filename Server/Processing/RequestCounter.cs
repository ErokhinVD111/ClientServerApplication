using System;

namespace Server.Processing
{
    public class RequestCounter
    {
        public int requestCount = 0;
        public int requestMaxCount;

        public RequestCounter()
        {
            Console.Write("Введите максимальное число запросов:");
            requestMaxCount = Int32.Parse(Console.ReadLine());
        }
    }
}