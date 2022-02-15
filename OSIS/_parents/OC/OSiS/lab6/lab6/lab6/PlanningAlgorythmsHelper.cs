namespace lab6
{
    static class PlanningAlgorythmsHelper
    {
        public static void WriteLog(Process[] processes, ProcessRunningSequence runningSequence, int i)
        {
            var log = new ProcessState[processes.Length];
            for (int j = 0; j < log.Length; j++)
                log[j] = processes[j].State;

            runningSequence.SetSequenceAtTick(log, i);
        }
    }
}
