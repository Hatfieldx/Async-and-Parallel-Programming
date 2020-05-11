using System;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {

            Task[] tasks = new Task[40];

            for (int i = 0; i < 40; i++)
            {
                var j = i;
                tasks[i] = new Task(() => Console.WriteLine($"Task # {j+1} done."));
            }

            var schedule = new StackTaskScheduler();
            
            Console.WriteLine("START TASKS: ");

            foreach (var item in tasks)
            {
                item.Start(schedule);
            }

            Console.ReadKey();
        }
    }
}
