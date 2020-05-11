using System;
using System.Threading;
using System.Threading.Tasks;

namespace part3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId}");

            await CalculateFactorialAsync(10);

            Console.WriteLine($"Main After task thread {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write("#");
            }

            Console.WriteLine($"Main ended thread {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();
        }

        static async Task CalculateFactorialAsync(int num)
        {
            await Task.Run(()=> {
                Console.WriteLine($"Task thread {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine(CalculateFactorial(num));
            });
            Console.WriteLine($"After Task thread {Thread.CurrentThread.ManagedThreadId}");
        }
        
        static double CalculateFactorial(int num)
        {
            Thread.Sleep(500);
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
}
