using System;

namespace lab6
{
    class FcfsBackward : IProcessPlanningAlgorythm
    {
        public ProcessRunningSequence Execute(Process[] processes)
        {
            var processesSorted = new Process[processes.Length];
            for (int i = 0; i < processes.Length; i++)
                processesSorted[i] = processes[i].Clone() as Process;

            var appearance = new int[processes.Length];
            for (int i = 0; i < processesSorted.Length; i++)            
                appearance[i] = processesSorted[i].Appearance;
            
            Array.Reverse(appearance);
            for (int i = 0; i < processesSorted.Length; i++)            
                processesSorted[i].Appearance = appearance[i];
            
            return new FcfsDirect().Execute(processesSorted);
        }
    }
}
