using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Client client = new Client();
                client.SendRequest(); 
                client.AcceptAnswerAsync();
            }
        }
    }
}