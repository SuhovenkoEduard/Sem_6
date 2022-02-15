using System.Collections.Generic;
using System.Linq;

namespace lab6
{
    class FcfsDirect : IProcessPlanningAlgorythm
    {
        public ProcessRunningSequence Execute(Process[] processes)
        {
            ProcessRunningSequence runningSequence = new ProcessRunningSequence(processes.Length, 19);

            Queue<Process> queue = new Queue<Process>();
            for (int i = 0; i < runningSequence.MaxT; i++)
            {
                // add all appearing processes at the current tick to the queue
                foreach (var item in processes.Where(x => x.Appearance == i && x.State == ProcessState.Void))   //             
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
    }
}
