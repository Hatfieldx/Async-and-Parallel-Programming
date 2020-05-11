using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace part4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(await ParseSiteAsync("https://itvdn.com"));

            Console.ReadKey();
        }

        private static async Task<int> ParseSiteAsync(string site)
        {
            var client = new HttpClient();

            string body = await client.GetStringAsync(site);

            using (StreamWriter sr = new StreamWriter("out.txt"))
            {
                await sr.WriteLineAsync(body);
            }

            return Regex.Matches(body, "itvdn", RegexOptions.IgnoreCase).Count;
        }
    }
}
