using System;
using System.Threading;
using System.Threading.Tasks;

namespace part3
{
    class Program
    {
        static Program()
        {
            SynchronizationContext.SetSynchronizationContext(new ErrorHandlerContext());
        }
        static void Main(string[] args)
        {
            MethodAsync();

            Console.ReadKey();
        }

        static async void MethodAsync()
        {
            Thread.Sleep(2000);

            await Task.Run(() =>
            {
                throw new Exception("Error");
            }
            );
        }
    }
}
