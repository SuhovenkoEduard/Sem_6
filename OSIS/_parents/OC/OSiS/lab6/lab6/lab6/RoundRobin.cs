using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6
{
    class RoundRobin : IProcessPlanningAlgorythm
    {
        public int CycleTicks { get; set; }

        public RoundRobin(int cycleTicks)
        {
            if (cycleTicks < 1)
                throw new ArgumentException();
            CycleTicks = cycleTicks;
        }

        public ProcessRunningSequence Execute(Process[] processes)
        {
            ProcessRunningSequence runningSequence = new ProcessRunningSequence(processes.Length, 19);

            Queue<Process> queue = new Queue<Process>();
            int cycleCounter = 0;
            for (int i = 0; i < runningSequence.MaxT; i++, cycleCounter++)
            {
                // add all appearing processes at the current tick to the queue
                foreach (var item in processes.Where(x => x.Appearance == i))   //&& x.State == ProcessState.Void
                {
                    item.State = ProcessState.Ready;
                    queue.Enqueue(item);
                }

                if (queue.Count > 0)
                {
                    if (queue.Peek().IsComplete)
                    {
                        // go to the next element in queue and set its state as void
                        queue.Dequeue().State = ProcessState.Void;
                        if (queue.Count > 0)
                            queue.Peek().State = ProcessState.Running;
                        cycleCounter = 0;
                    }
                    else if((cycleCounter+1) % (CycleTicks+1) == 0)
                    {
                        var deq = queue.Dequeue();
                        deq.State = ProcessState.Ready;
                        queue.Enqueue(deq);
                        cycleCounter = 0;
                        queue.Peek().State = ProcessState.Running;
                    }
                    else
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
    }
}
