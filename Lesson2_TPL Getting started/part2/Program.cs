using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 4, 4, 2, 5, 8, 1, 9, 34, 45, 12, 4, 5, 9, 12, 4, 23, 54, 12 }; 
            
            
            Task.Run(() => SortArray(false, a))
                .ContinueWith(a =>
                {
                    foreach (var item in a.Result)
                    {
                        Console.Write($"{item}, ");
                    }                
                });

            Console.ReadKey();
        }

        private static int[] SortArray(bool isAscending, params int[] array)
        {
            Array.Sort(array);

            if (!isAscending)
            {
                Array.Reverse(array);
            }

            return array;
        }
    }
}
