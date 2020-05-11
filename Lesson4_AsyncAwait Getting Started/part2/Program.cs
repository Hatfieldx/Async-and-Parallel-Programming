using System;
using System.Threading.Tasks;
using System.Threading;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread main {0}", Thread.CurrentThread.ManagedThreadId);

            CalculateFactorialAsync(10).DisableAsyncWarning();

            Console.WriteLine("Thread main loop {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(100);                
                Console.Write("#");
            }

            Console.WriteLine("Thread main after loop {0}", Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }

        static async Task CalculateFactorialAsync(int num)
        {
            await Task.Run(() => Console.WriteLine(CalculateFactorial(num)));

            Console.WriteLine("Thread after solve factorial {0}", Thread.CurrentThread.ManagedThreadId);

        }

        static double CalculateFactorial(int num)
        {
            Thread.Sleep(1000);

            Console.WriteLine("Thread solve factorial {0}", Thread.CurrentThread.ManagedThreadId);

            if (num == 0)
            {
                return 1;
            }
            else
            {
                return num * CalculateFactorial(num - 1);
            }
        }
    }

    public static class TaskExtensions
    {
        public static void DisableAsyncWarning(this Task task)
        { 
        }
    }
}
