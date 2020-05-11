using System;
using System.Threading;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static Program()
        {
            SynchronizationContext.SetSynchronizationContext(new CustomSinchronizationContext());
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"MAIN Thread id {Thread.CurrentThread.ManagedThreadId} Name: {Thread.CurrentThread.Name} IsThreadPoolThread : {Thread.CurrentThread.IsThreadPoolThread}");            

            CalculateFactorialAsync(10);

            Console.WriteLine($"MAIN After Thread id {Thread.CurrentThread.ManagedThreadId} Name: {Thread.CurrentThread.Name} IsThreadPoolThread : {Thread.CurrentThread.IsThreadPoolThread}");

            Console.ReadKey();
        }

        static async Task CalculateFactorialAsync(int num)
        {
            Console.WriteLine($"before task Thread id {Thread.CurrentThread.ManagedThreadId} Name: {Thread.CurrentThread.Name} IsThreadPoolThread : {Thread.CurrentThread.IsThreadPoolThread}");

            await Task.Run(() => Console.WriteLine(CalculateFactorial(num).ToString()));

            ThreadPool.QueueUserWorkItem((_) => Console.WriteLine($"after task Thread id {Thread.CurrentThread.ManagedThreadId} Name: {Thread.CurrentThread.Name} IsThreadPoolThread : {Thread.CurrentThread.IsThreadPoolThread}"));

            Console.WriteLine($"after task Thread id {Thread.CurrentThread.ManagedThreadId} Name: {Thread.CurrentThread.Name} IsThreadPoolThread : {Thread.CurrentThread.IsThreadPoolThread}");
        }

        static double CalculateFactorial(int num)
        {
            Thread.Sleep(2000);

            double res = 1;

            if (num == 0) 
                return res;
            
            for (int i = 1; i <= num; i++)
            {
                res *= i;
            }
            
            Thread.Sleep(2000);

            return res;
        }
    }
}
