using System.Collections.Generic;
using System.Linq;

namespace lab6
{
    class Sjf : IProcessPlanningAlgorythm
    {
        IComparer<Process> comparer;
        bool dislodging;

        public Sjf(bool dislodging = false, bool prioritial = false)
        {
            if (prioritial)
                comparer = new ProcessPriorityComparer();
            else
                comparer = new ProcessDurationComparer();

            this.dislodging = dislodging;
        }

        public ProcessRunningSequence Execute(Process[] processes)
        {
            ProcessRunningSequence runningSequence = new ProcessRunningSequence(processes.Length, 19);

            Queue<Process> queue = new Queue<Process>();

            // add all appearing processes at the btggining to the queue
            // then choose min element as the beggining of the queue
            int k = 0;
            for (k = 0; k < runningSequence.MaxT && queue.Count == 0; k++)
            {
                foreach (var item in processes.Where(x => x.Appearance == k))
                {
                    item.State = ProcessState.Ready;
                    queue.Enqueue(item);
                }
                RollQueueToItem(queue, MinItem(queue));
            }
            if (queue.Count > 0)
            {
                queue.Peek().State = ProcessState.Running;
                queue.Peek().DurationResource--;
                PlanningAlgorythmsHelper.WriteLog(processes, runningSequence, k-1);
            }

            for (int i = k; i < runningSequence.MaxT; i++)
            {
                // add all appearing processes at the current tick to the queue
                int queuePrevCount = queue.Count();
                foreach (var item in processes.Where(x => x.Appearance == i && x.State == ProcessState.Void))             
                {
                    item.State = ProcessState.Ready;
                    queue.Enqueue(item);
                }
                if (dislodging && queuePrevCount - queue.Count() != 0 && queue.Peek().DurationResource != 0)
                {
                    queue.Peek().State = ProcessState.Ready;
                    RollQueueToItem(queue, MinItem(queue));
                    queue.Peek().State = ProcessState.Running;
                }

                if (queue.Count > 0)
                {
                    if (queue.Peek().IsComplete)
                    {
                        // set the complete process state as void
                        queue.Dequeue().State = ProcessState.Void;
                        // go to the next min element in queue
                        if (queue.Count > 0)
                            RollQueueToItem(queue, MinItem(queue));
                    }
                    if (queue.Count > 0)
                        queue.Peek().State = ProcessState.Running;
                }

                PlanningAlgorythmsHelper.WriteLog(processes, runningSequence, i);

                if (queue.Count > 0)
                    queue.Peek().DurationResource--;
            }

            foreach (var item in processes)
            {
                item.ResetProcess();
            }

            return runningSequence;
        }

        public Process MinItem(Queue<Process> processes)
        {
            // processes may not be void
            Process minItem = processes.Dequeue();
            processes.Enqueue(minItem);
            for (int i = 1; i < processes.Count; i++)
            {
                var item = processes.Dequeue();
                if (comparer.Compare(item, minItem) < 0)
                    minItem = item;
                processes.Enqueue(item);
            }

            return minItem;
        }

        public void RollQueueToItem(Queue<Process> processes, Process process)
        {
            // processes may not be void
            for (int i = 0; i < processes.Count; i++)
            {
                var item = processes.Peek();
                if (comparer.Compare(item, process) != 0)
                {
                    item = processes.Dequeue();
                    processes.Enqueue(item);
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} : {(dislodging ? "" : "not ")}dislodging, " +
                $"{(comparer.GetType() == typeof(ProcessPriorityComparer) ? "" : "not ")}prior";
        }
    }
}
