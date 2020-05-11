using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace part2
{
    class StackTaskScheduler : TaskScheduler
    {

        Stack<Task> _taskList;

        public StackTaskScheduler()
        {
            _taskList = new Stack<Task>();
        }

        protected override IEnumerable<Task> GetScheduledTasks() => _taskList;

        protected override void QueueTask(Task task)
        {
            lock (_taskList)
            {
                _taskList.Push(task);
                ThreadPool.QueueUserWorkItem(ExecuteTask, null);
            }
        }

        private void ExecuteTask(object state)
        {
            while (true)
            {
                Task t;
                
                lock (_taskList)
                {
                    if (_taskList.Count == 0)
                        break;

                    t = _taskList.Pop();

                    if (t == null)
                        continue;

                    TryExecuteTask(t);
                }
            }
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            throw new NotImplementedException();
        }
    }
}
