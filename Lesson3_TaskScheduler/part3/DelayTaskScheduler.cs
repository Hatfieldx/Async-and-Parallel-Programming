using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace part3
{
    class DelayTaskScheduler : TaskScheduler
    {
        LinkedList<Task> _tasks = new LinkedList<Task>();

        protected override IEnumerable<Task> GetScheduledTasks() => _tasks;

        protected override void QueueTask(Task task)
        {
            lock (_tasks)
            {
                _tasks.AddFirst(task);
                Timer timer = new Timer(ExecuteTask, null, 2000, 1);
            }
        }
        private void ExecuteTask(object state)
        {
            while (true)
            {
                Task t;

                lock (_tasks)
                {
                    if (_tasks.Count == 0)
                        break;

                    t = _tasks.First.Value;

                    _tasks.RemoveFirst();
                }

                TryExecuteTask(t);
            }
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) => false;
    }
}
