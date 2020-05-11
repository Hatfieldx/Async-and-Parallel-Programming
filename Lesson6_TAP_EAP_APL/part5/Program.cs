using System;
using System.Threading.Tasks;

namespace part5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(await GetQueue(100));

            Console.ReadKey();
        }

        private static async Task<string> GetQueue(int num)
        {
            var tcs = new TaskCompletionSource<string>();

            tcs.TrySetResult(await Task.Run(() => {

                string s = "";

                for (int i = 0; i <= num; i++)
                {
                    s += i.ToString();
                }

                return s;
            }));

            return await tcs.Task;            
        }
    }
}
