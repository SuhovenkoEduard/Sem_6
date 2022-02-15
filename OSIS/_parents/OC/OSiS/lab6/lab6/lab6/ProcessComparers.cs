using System.Collections.Generic;

namespace lab6
{
    class ProcessPriorityComparer : IComparer<Process>
    {
        ProcessDurationComparer durationComparer = new ProcessDurationComparer();

        public int Compare(Process x, Process y)
        {
            var res = x.Priority.CompareTo(y.Priority);
            return res != 0 ? res : durationComparer.Compare(x, y);
        }
    }

    class ProcessDurationComparer : IComparer<Process>
    {        
        public int Compare(Process x, Process y)
        {
            return x.DurationResource.CompareTo(y.DurationResource);
        }
    }
}
