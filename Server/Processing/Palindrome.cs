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
            dataFromClient = dataFromClient.Replace(" ", "");

            char[] chars = dataFromClient.ToCharArray();

            for (int i = 0; i < chars.Length / 2; i++)
            {
                if (Char.ToLower(chars[i]) != Char.ToLower(chars[chars.Length - i - 1]))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}