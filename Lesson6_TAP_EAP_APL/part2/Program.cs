using System;
using System.IO;
using System.Text;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "output.txt";
            
            Console.WriteLine("Enter some text (write q for exit):");

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 4096, FileOptions.Asynchronous))

            using (StreamWriter sr = new StreamWriter(fs, Encoding.UTF8))

                while (true)
                {
                    string text = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("Enter some text (write q for exit):");
                        continue;
                    }

                    if (text == "q")
                    {
                        break;
                    }

                    sr.WriteLineAsync(text);
                }

            Console.ReadKey();
        }
    }
}
