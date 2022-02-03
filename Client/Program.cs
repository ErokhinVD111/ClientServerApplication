using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IteratorFiles iterator = new IteratorFiles();
            start:
            string[] files = GetFilesFromPath();
            if (files == null)
                goto start;
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i}. {files[i]}");
            }
            while (true)
            {
                TCPClient tcpClient = new TCPClient(files, iterator);
                tcpClient.SendRequest();
                tcpClient.AcceptAnswerAsync();   
            }
            
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
                return null;
            }
        }
    }
}