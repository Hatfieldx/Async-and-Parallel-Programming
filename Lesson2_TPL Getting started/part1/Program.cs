using System;
using System.Threading;
using System.Threading.Tasks;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Factory.StartNew(WriteChar, '!');

            t.ContinueWith((x) => Console.WriteLine("MAIN is FIN"));

            for (int i = 0; i < 160; i++)
            {                
                Console.Write("$");
            }         

            Console.ReadKey();
        }

        private static void WriteChar(object symbol)
        {
            var x = symbol.ToString();
            
            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(500);
                Console.Write(x);
            }
        }
    }
}
