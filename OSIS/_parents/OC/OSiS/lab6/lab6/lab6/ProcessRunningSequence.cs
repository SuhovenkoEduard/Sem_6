using System;
using System.Text;

namespace lab6
{
    class ProcessRunningSequence
    {
        public static char VoidSymbol { get; set; } = ' ';
        public static char ReadySymbol { get; set; } = 'Г';
        public static char RunningSymbol { get; set; } = 'И';
        
        public int MaxT { get; set; } = 0;
        public int ProcessesCount { get { return sequence.Length; } }
        ProcessState[][] sequence;


        public ProcessRunningSequence(int processesCount, int maxT)
        {
            sequence = new ProcessState[processesCount][];
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = new ProcessState[maxT];
            }
            MaxT = maxT;
        }

        public void SetSequenceAtTick(ProcessState[] sequence, int tickI)
        {
            if (sequence.Length != ProcessesCount)
                throw new ArgumentException();

            for (int i = 0; i < ProcessesCount; i++)            
                this.sequence[i][tickI] = sequence[i];            
            
            if (MaxT < sequence.Length)
                MaxT = sequence.Length;
        }

        private static char GetValueSymbol(ProcessState value)
        {
            return 
                value == ProcessState.Running ? RunningSymbol :
                value == ProcessState.Ready ? ReadySymbol :
                VoidSymbol;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(new string('_',  7+6* MaxT) + Environment.NewLine );
            stringBuilder.Append($"| p\\t |");
            for(int i = 0; i < MaxT; i++)            
                stringBuilder.Append($" {i:d3} |");
            stringBuilder.Append(Environment.NewLine);

            for (int i = 0; i < sequence.Length; i++)
            {
                stringBuilder.Append($"| p{i:d2} |");
                for (int j = 0; j < MaxT; j++)
                    stringBuilder.Append($"  {GetValueSymbol(sequence[i][j])}  |");
                stringBuilder.Append(Environment.NewLine);
            }

            stringBuilder.Append(new string('_', 7+6*MaxT));

            return stringBuilder.ToString();
        }
    }
}
