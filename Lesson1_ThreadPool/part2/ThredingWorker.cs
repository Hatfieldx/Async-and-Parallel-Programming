using System;
using System.Threading;

namespace part2
{
    class ThreadingWorker
    {
        readonly Action<object> _action;

        public ThreadingWorker(Action<object> action)
        {
            _action = action ?? throw new NullReferenceException();
        }

        public bool Success { get; private set; } = false;
        public bool Complete { get; private set; } = false;
        public Exception Ex { get; private set; } = null;

        public void Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Do), state);
        }

        public void Wait()
        {
            while (Complete == false)
            {
                Thread.Sleep(50);
            }

            if (Ex != null)
            {
                throw Ex;
            }
        }

        private void Do(object state)
        {
            try
            {
                _action.Invoke(state);
                Success = true;
            }
            catch (Exception ex)
            {
                Ex = ex;
                Success = false;
            }
            finally
            {
                Complete = true;
            }
        }

    }
}
