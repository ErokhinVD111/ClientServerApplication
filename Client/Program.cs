using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static List<TCPClient> clientsRun = new List<TCPClient>();
        static string[] files = GetFilesFromPath();
        static IteratorFiles iterator = new IteratorFiles();

        static void Main(string[] args)
        {
            // while (true)
            // {
            //     Run();   
            // }
            //bool stop = false;
            // while (iterator.Iterator < files.Length)
            // {
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i}. {files[i]}");
            }
            while (true)
            {
                TCPClient tcpClient = new TCPClient(files, iterator) {IteratorFiles = iterator};
                tcpClient.SendRequest();
                tcpClient.AcceptAnswerAsync();   
            }
            // TCPClient tcpClient = new TCPClient(files, iterator) {IteratorFiles = iterator};
            // tcpClient.SendRequest();
            // tcpClient.AcceptAnswerAsync();
            //     clientsRun.Add(tcpClient);
            // }
            // foreach (var client in clientsRun)
            // {
            //     if (client.TcpAcceptor.answer.Equals("Большое количество запросов! Подождите."))
            //     {
            //         iterator.Iterator--;
            //     }
            // }

            // if (iterator.Iterator > files.Length)
            //     break;
            //iterator.Iterator++;
            //Console.WriteLine(iterator.Iterator);

            #region comments

            // if (!stop)
            //     iterator.Iterator++;
            // if (stop)
            // {
            //     foreach (var client in clientsRun)
            //     {
            //         if (!client.TcpAcceptor.answer.Equals("Большое количество запросов! Подождите."))
            //         {
            //             stop = false;
            //         }
            //     }
            // }

            // bool checkState = false;
            // if (client.TcpAcceptor.answer.Equals("Большое количество запросов! Подождите."))
            // {
            //     while (true)
            //     {
            //         for (int i = 0; i < clientsRun.Count; i++)
            //         {
            //             if (!clientsRun[i].TcpAcceptor.answer.Equals("Большое количество запросов! Подождите"))
            //             {
            //                 checkState = true;
            //                 iterator.Iterator--;
            //                 break;
            //             }
            //         }
            //
            //         if (checkState)
            //             break;
            //     }
            // }
            // else
            // {
            //     iterator.Iterator++;
            // }
            // if (checkState)
            //     break;

            #endregion
        }

        static async Task Run()
        {
            TCPClient tcpClient = new TCPClient(files, iterator) {IteratorFiles = iterator};
            tcpClient.SendRequest();
            await Task.Delay(10);
            await Task.Run(() => tcpClient.AcceptAnswerAsync());
            //clientsRun.Add(tcpClient);

            //
            // foreach (var client in clientsRun)
            // {
            //     if (client.TcpAcceptor.answer.Equals("Большое количество запросов! Подождите."))
            //     {
            //         iterator.Iterator--;
            //     }
            // }
        }

        public static string[] GetFilesFromPath()
        {
            Console.WriteLine("Введите путь до папки:");

            string path = Console.ReadLine();
            try

            {
                string[] allfiles = Directory.GetFiles(path);
                return allfiles;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Папка не найдена: {0}", path);
            }

            return null;
        }
    }
}