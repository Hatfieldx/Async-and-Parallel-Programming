using System;
using System.Threading;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Ex1 = new WaitCallback(WriteChar);

            var Ex2 = new WaitCallback(WriteChar);

            ThreadPool.QueueUserWorkItem(Ex1, '*');            

            ThreadPool.QueueUserWorkItem(Ex2, '!');           

            Console.ReadKey();
        }

        public static void WriteChar(object x)
        {
           char y = (char)x;
            
            for (int i = 0; i < 160; i++)
            {
                Console.Write(y);
                Thread.Sleep(100);
            }
        }
    }
}
