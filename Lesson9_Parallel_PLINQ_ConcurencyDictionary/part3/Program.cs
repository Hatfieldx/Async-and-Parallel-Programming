using System;
using System.Linq;
using System.Threading.Tasks;

namespace part3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10_000];

            var res = Parallel.For(0, a.Length - 1, x => a[x] = x);

            if (res.IsCompleted)
            {
                (from item in a
                  .AsParallel()
                  .AsOrdered()
                 where item % 2 == 0
                 select item)
                        .ForAll(x => Console.Write($" {x} "));

            }



            Console.ReadKey();
        }
    }
}
