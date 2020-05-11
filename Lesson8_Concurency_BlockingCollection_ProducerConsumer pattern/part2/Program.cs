using System;
using System.Threading;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            
            Action MakeAnOrder = () =>
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started");
                
                for (int i = 0; i < 1_0000; i++)
                {
                    shop.MakeAnOrder($"prod name {i}", i);
                }

                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished");
            };

            Action ProcessOrders = () =>
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started");
                shop.ProcessOrders();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished");
            };


            var prod1 = Task.Run(MakeAnOrder);
            var prod2 = Task.Run(MakeAnOrder);

            var consumer = Task.Run(ProcessOrders);

            Task.WaitAll(prod1, prod2);

            shop.BuyingComplete();

            Console.ReadKey();
        }        
    }
}
