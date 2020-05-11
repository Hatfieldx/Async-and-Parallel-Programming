using System;
using System.Threading.Tasks;

namespace path3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => FindLastFibonacciNumber(5), TaskCreationOptions.LongRunning)
                .ContinueWith(x => Console.WriteLine(x.Result));

            Console.ReadKey();
        }

        private static double FindLastFibonacciNumber(int number)
        {
            Func<int, double> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            return fib.Invoke(number);
        }
    }
}
