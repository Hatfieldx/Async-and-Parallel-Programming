using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Threading;

namespace part4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main started thread {Thread.CurrentThread.ManagedThreadId}");
            string path = "source.txt";

            string path1 = "output.txt";

            string res = File.ReadAllText(path);

            Task<IList<string>> words = ParseAsync(res);

            Console.WriteLine($"Main after invoke thread {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Введите имя: ");

            string name = Console.ReadLine();

            var fs = new FileStream(path1, FileMode.Append);

            StreamWriter sw = new StreamWriter(fs);

            Console.WriteLine($"Main before return thread {Thread.CurrentThread.ManagedThreadId}");

            var parseResult = await words;

            Console.WriteLine($"Main after return thread {Thread.CurrentThread.ManagedThreadId}");

            sw.WriteLine($"{name} нашел { parseResult.Count} уникальных слов. Перечисление слов: ");

            for (int i = 0; i < parseResult.Count; i++)
            {
                sw.Write(parseResult[i] + ((i == parseResult.Count - 1) ? "." : ", "));
            }

            sw.Close();
            fs.Close();
            
            Console.ReadKey();
        }

        static async Task<IList<string>> ParseAsync(string inputData)
        {
            Console.WriteLine($"Method started thread {Thread.CurrentThread.ManagedThreadId}");

            return await Task.Run(() =>
            {
                Thread.Sleep(10000);
                
                Console.WriteLine($"Method processing thread {Thread.CurrentThread.ManagedThreadId}");

                var words = inputData.Split(new char[] { '.', ',', ' '}, StringSplitOptions.RemoveEmptyEntries);

                return words.Distinct().ToList();
            });            
        }
    }
}
