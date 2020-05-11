using System;
using System.Threading.Tasks;
using System.Threading;

namespace part3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"MAIT THREAD: {Thread.CurrentThread.ManagedThreadId}");
            
            Task t = new Task(() => Console.WriteLine($"Task thread = {Thread.CurrentThread.ManagedThreadId}, Thread pool = {Thread.CurrentThread.IsThreadPoolThread}"));

            var sched = new DelayTaskScheduler();
            
            t.Start(sched);

            while (!t.IsCompleted)
            {
                Console.Write("*");
                Thread.Sleep(100);
            }

            Console.ReadKey();
        }
    }
}
