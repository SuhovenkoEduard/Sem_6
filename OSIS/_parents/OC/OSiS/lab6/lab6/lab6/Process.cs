namespace lab6
{
    public enum ProcessState { Void, Ready, Running }

    public class Process : System.ICloneable
    {
        public int Duration { get; set; }
        public int Appearance { get; set; }
        public int Priority { get; set; }

        public int DurationResource { get; set; }

        public ProcessState State { get; set; } = ProcessState.Void;
        public bool IsComplete { get { return DurationResource == 0; } }

        public Process(int dur, int appear, int prior)
        {
            DurationResource = Duration = dur;
            Appearance = appear;
            Priority = prior;
        }

        public void ResetProcess()
        {
            DurationResource = Duration;
            State = ProcessState.Void;
        }

        public object Clone()
        {
            return new Process(Duration, Appearance, Priority);
        }
    }
}
