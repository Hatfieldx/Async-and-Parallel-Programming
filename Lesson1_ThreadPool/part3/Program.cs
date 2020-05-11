using System;
using System.Threading;

namespace part3
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new ThreadingWorker<bool>(WriteChar);

            bool r1 = t1.Start('*');

            var t2 = new ThreadingWorker<bool>(WriteChar);

            bool r2 = t2.Start('@');

            Console.WriteLine("FIN");
            Console.ReadKey();
        }

        public static bool WriteChar(object x)
        {
            char y = (char)x;

            for (int i = 0; i < 160; i++)
            {
                Console.Write(y);
                Thread.Sleep(100);
            }

            return true;
        }
    }
}
