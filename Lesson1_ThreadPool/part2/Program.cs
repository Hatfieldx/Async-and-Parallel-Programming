using System;
using System.Threading;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new ThreadingWorker(WriteChar);

            t1.Start('*');

            var t2 = new ThreadingWorker(WriteChar);

            t2.Start('@');

            t1.Wait();
            t2.Wait();


            Console.WriteLine("FIN");
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
