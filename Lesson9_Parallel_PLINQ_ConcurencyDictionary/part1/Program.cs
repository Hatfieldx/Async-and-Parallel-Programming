using System;
using System.Threading.Tasks;
using System.Linq;

namespace part1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            int[] a = new int [10_000_000];

            var res = Parallel.For(0, a.Length - 1, x => a[x] = x);

            if (res.IsCompleted)
            {
              (from item in a
                .AsParallel()
                where (item & (item - 1)) == 0
                      select item)
                      .ForAll(x => Console.Write($" {x} "));

            }
            Console.ReadKey();
        }
    }
}
