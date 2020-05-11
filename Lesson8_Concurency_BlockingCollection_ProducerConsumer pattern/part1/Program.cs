using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10_000_000];

            Action<int> action = x =>
            {
                a[x] = x;
            };

            var timer = new Stopwatch();

            timer.Start();

            Parallel.For(0, a.Length - 1, action);

            timer.Stop();

            Console.WriteLine(timer.ElapsedMilliseconds);

            timer.Restart();

            ConcurrentQueue<int> b = new ConcurrentQueue<int>();

            Action<int> looper = x =>
            {
                if ((x & (x-1)) == 0)
                {
                    b.Enqueue(x);
                }
            };

            Parallel.ForEach(a, looper);

            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds + "\n");

            foreach (var item in b)
            {
                Console.Write(item + "  ");
            }
            
            Console.ReadKey();
        }
    }
}
