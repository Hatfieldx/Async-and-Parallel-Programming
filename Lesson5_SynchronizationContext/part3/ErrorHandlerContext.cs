using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace part3
{
    class ErrorHandlerContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                try
                {
                    d(state);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR!!!!!" + ex?.Message);
                }
            } );
        }
    }
}
