using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace part2
{
    class CustomSinchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Console.WriteLine("POST");
            
            var job = new Thread(() => d?.Invoke(state));

            job.Name = "Custom SC thread";
            
            job.Start();
        }
    }
}
