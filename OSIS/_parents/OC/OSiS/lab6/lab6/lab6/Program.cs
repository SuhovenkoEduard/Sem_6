using System;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = new Process[]
            {
                new Process(10, 2, 1),   //p0
                new Process(3, 0, 3),   //p1
                new Process(3, 4, 3),   //p2
                new Process(7, 5, 2)    //p3
            };
            
            IProcessPlanningAlgorythm[] algorythms = new IProcessPlanningAlgorythm[]
            {
                new FcfsDirect(),       // FCFS direct
                new FcfsBackward(),     // FCFS back
                new RoundRobin(3),      // RR
                new Sjf(false, false),  // Sjf not dislodging, not priorital
                new Sjf(false, true),   // Sjf not dislodging,     priorital
                new Sjf(true, false),   // Sjf     dislodging, not priorital
                new Sjf(true, true)     // Sjf     dislodging,     priorital
            };
            
            foreach (var a in algorythms)
            {
                Console.WriteLine(a.ToString());
                Console.WriteLine(a.Execute(processes));
                Console.WriteLine();
            }

            Console.ReadKey();
        }        
    }
}
