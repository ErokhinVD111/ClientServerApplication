using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Server.Processing
{
    /// <summary>
    /// Класс реализующий проверку файла на палиндром
    /// </summary>
    public class Palindrome : ITypeProcessing
    {
        public void Run()
        {
            
        }
        
        public bool Run(string dataFromClient)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(dataFromClient, Encoding.Default);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден: {0}", dataFromClient);
                return false;
            }

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Replace(" ", "");
                
                char[] chars = line.ToCharArray();

                for (int i = 0; i < chars.Length / 2; i++)
                {
                    if (Char.ToLower(chars[i]) != Char.ToLower(chars[chars.Length - i - 1]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}