using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace part3
{
    class ThreadingWorker<TResult>
    {
        private readonly Func<object, TResult> _func;

        TResult result = default;

        public bool Success { get; private set; } = false;
        public bool Complete { get; private set; } = false;
        public Exception Ex { get; private set; } = null;

        public TResult Result
        {
            get
            {
                while (Complete == false)
                {
                    Thread.Sleep(50);
                }

                if (Ex != null)
                    throw Ex;

                return result;
            }
        }

        public ThreadingWorker(Func<object, TResult> func)
        {
            _func = func ?? throw new NullReferenceException();
        }

        public TResult Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Do), state);

            return Result;
        }

        private void Do(object state)
        {
            try
            {
                result = _func.Invoke(state);

                Success = true;
            }
            catch (Exception ex)
            {
                Ex = ex;
                Success = false;
                result = default;
            }
            finally
            {
                Complete = true;
            }
        }
    }
}
