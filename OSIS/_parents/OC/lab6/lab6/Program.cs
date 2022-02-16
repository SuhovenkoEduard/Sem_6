using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OC_LAB_6
{
    class Proc : IComparable<Proc>
    {
        public int WaitTime { get; set; }
        public int BurstTime { get; set; }
        public static int Capacity { get; set; }
        public int G { get; set; }
        public int I { get; set; }
        public int AppearTime { get; set; }

        public Proc(int burst, int appear)
        {
            BurstTime = burst;
            AppearTime = appear;
        }

        public int CompareTo(Proc other)
        {
            return AppearTime.CompareTo(other.AppearTime);
        }
    }
    class Program
    {
        static int[] p_t = new int[] { 7, 8, 3, 4 };//birt
        static int[] p_ap = new int[] { 4, 0, 3, 5 };//per
        static int[] p_pr = new int[] { 1, 2, 3, 4 };

        static void Main(string[] args)
        {
            List<Proc> processes = new List<Proc>();
            processes.Add(new Proc(7, 4)); processes.Add(new Proc(8, 0)); processes.Add(new Proc(3, 3)); processes.Add(new Proc(4, 5));
            Console.WriteLine("FCFS - прямой\n-----------------");
            FCFS_Direct(p_t, p_ap, processes);
            Out(processes);
            Console.WriteLine();

            Console.WriteLine("FCFS - обратный\n-----------------");
            FCFS_Reverse(p_t, p_ap, processes);
            Console.WriteLine();
            Out(processes);

            Console.WriteLine("RR\n-----------------");
            RR(p_t, p_ap, processes);
            Out(processes);
            Console.WriteLine();

            Console.WriteLine("SJF невытесняющий, без приоритета\n-----------------");
            SJF_NoDisloge_NoPriority(p_t, p_ap, processes);
            Out(processes);
            Console.WriteLine();

            Console.WriteLine("SJF невытесняющий, с приоритетом\n-----------------");
            SJF_NoDisloge_Priority(p_t, p_ap, p_pr, processes);
            Out(processes);
            Console.WriteLine();

            Console.WriteLine("SJF вытесняющий, без приоритета\n-----------------");
            SJF_Disloge_NoPriority(p_t, p_ap, processes);
            Out(processes);
            Console.WriteLine();

            Console.WriteLine("SJF вытесняющий, с приоритетом\n-----------------");
            SJF_Disloge_Priority(p_t, p_ap, p_pr, processes);
            Out(processes);
            Console.WriteLine();
            Console.ReadLine();
        }

        static void FCFS_Direct(int[] p_t, int[] p_app, List<Proc> processes)
        {
            foreach (var pr in processes)
            {
                pr.G = 0;
                pr.I = 0;
            }
            var p = p_t.ToArray(); //copy array
            var workedIndex = -1;
            var proccessQueue = new Queue<int>();
            for (var i = 0; p.Sum() != 0; i++)
            {
                for (var j = 0; j < p_ap.Length; j++)
                {
                    if (workedIndex >= 0 && p_ap[j] == i)
                        proccessQueue.Enqueue(j);     //добавить в конец
                    else if (workedIndex < 0 && p_ap[j] == i && proccessQueue.Count == 0)
                        workedIndex = j;
                    else if (workedIndex < 0 && p_ap[j] == i && proccessQueue.Count != 0)
                    {
                        proccessQueue.Enqueue(j);
                        workedIndex = proccessQueue.Dequeue();    //достать из начала
                    }
                    else if (workedIndex < 0 && p_ap[j] != i && proccessQueue.Count != 0)
                        workedIndex = proccessQueue.Dequeue();
                }
                PrintLine(i, FormArr(p, p_ap, i), workedIndex, processes);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void FCFS_Reverse(int[] p_t, int[] p_app, List<Proc> procs)
        {
            foreach (var pr in procs)
            {
                pr.G = 0;
                pr.I = 0;
            }
            var p = p_t.ToArray();

            var workedIndex = -1;
            var proccessStack = new Stack<int>();
            for (var i = 0; p.Sum() != 0; i++)
            {
                for (var j = p_ap.Length - 1; j >= 0; j--)
                {
                    if (workedIndex >= 0 && p_ap[j] == i)
                    {
                        proccessStack.Push(j);
                    }
                    else if (workedIndex < 0 && p_ap[j] == i && proccessStack.Count == 0)
                        workedIndex = j;
                    else if (workedIndex < 0 && p_ap[j] == i && proccessStack.Count != 0)
                    {
                        workedIndex = proccessStack.Pop();
                        proccessStack.Push(j);
                    }
                    else if (workedIndex < 0 && p_ap[j] != i && proccessStack.Count != 0)
                        workedIndex = proccessStack.Pop();
                }
                PrintLine(i, FormArr(p, p_ap, i), workedIndex, procs);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
            int a = 0;
        }

        static void RR(int[] p_t, int[] p_app, List<Proc> procs)
        {
            foreach (var pr in procs)
            {
                pr.I = 0;
                pr.G = 0;
            }
            var p = p_t.ToArray();
            var workedIndex = -1;
            var workedTime = 0;
            var proccessQueue = new Queue<int>();
            for (var i = 0; p.Sum() != 0; i++)
            {
                for (var j = 0; j < p_ap.Length; j++)
                {
                    if (workedIndex >= 0 && p_ap[j] == i)
                        proccessQueue.Enqueue(j);
                    else if (workedIndex < 0 && p_ap[j] == i && proccessQueue.Count == 0)
                    {
                        workedIndex = j;
                        workedTime = 3;
                    }
                    else if (workedIndex < 0 && p_ap[j] == i && proccessQueue.Count != 0)
                    {
                        proccessQueue.Enqueue(j);
                        workedIndex = proccessQueue.Dequeue();
                        workedTime = 3;
                    }
                    else if (workedIndex < 0 && p_ap[j] != i && proccessQueue.Count != 0)
                    {
                        workedIndex = proccessQueue.Dequeue();
                        workedTime = 3;
                    }
                }
                PrintLine(i, FormArr(p, p_ap, i), workedIndex, procs);
                if (workedIndex >= 0)
                {
                    workedTime--;
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                    else if (workedTime == 0)
                    {
                        proccessQueue.Enqueue(workedIndex);
                        workedIndex = -1;
                    }
                }
            }
        }

        static void SJF_NoDisloge_NoPriority(int[] p_t, int[] p_app, List<Proc> procs)
        {
            foreach (var item in procs)
            {
                item.G = 0;
                item.I = 0;
            }
            var p = p_t.ToArray();
            var workedIndex = -1;
            var proccessList = new List<int>();
            for (var i = 0; p.Sum() != 0; i++)
            {
                for (var j = 0; j < p_ap.Length; j++)
                {
                    if (workedIndex >= 0 && p_ap[j] == i)
                        proccessList.Insert(FindPosition_NonPriority(p[j], proccessList, p), j);
                    else if (workedIndex < 0 && p_ap[j] == i && proccessList.Count == 0)
                        workedIndex = j;
                    else if (workedIndex < 0 && p_ap[j] == i && proccessList.Count != 0)
                    {
                        proccessList.Insert(FindPosition_NonPriority(p[j], proccessList, p), j);
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                    else if (workedIndex < 0 && p_ap[j] != i && proccessList.Count != 0)
                    {
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                }
                PrintLine(i, FormArr(p, p_ap, i), workedIndex, procs);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void SJF_NoDisloge_Priority(int[] p_t, int[] p_app, int[] p_pr, List<Proc> procs)
        {
            foreach (var item in procs)
            {
                item.G = 0;
                item.I = 0;
            }
            var p = p_t.ToArray();
            var workedIndex = -1;
            var proccessList = new List<int>();
            for (var i = 0; p.Sum() != 0; i++)
            {
                for (var j = 0; j < p_ap.Length; j++)
                {
                    if (workedIndex >= 0 && p_ap[j] == i)
                        proccessList.Insert(FindPosition_Priority(p_pr[j], proccessList, p_pr), j);
                    else if (workedIndex < 0 && p_ap[j] == i && proccessList.Count == 0)
                        workedIndex = j;
                    else if (workedIndex < 0 && p_ap[j] == i && proccessList.Count != 0)
                    {
                        proccessList.Insert(FindPosition_Priority(p_pr[j], proccessList, p_pr), j);
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                    else if (workedIndex < 0 && p_ap[j] != i && proccessList.Count != 0)
                    {
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                }
                PrintLine(i, FormArr(p, p_ap, i), workedIndex, procs);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void SJF_Disloge_NoPriority(int[] p_t, int[] p_app, List<Proc> procs)
        {
            foreach (var item in procs)
            {
                item.G = 0;
                item.I = 0;
            }
            var p = p_t.ToArray();
            var workedIndex = -1;
            var proccessList = new List<int>();
            for (var i = 0; p.Sum() != 0; i++)
            {
                for (var j = 0; j < p_ap.Length; j++)
                {
                    if (workedIndex >= 0 && p_ap[j] == i)
                    {
                        proccessList.Insert(FindPosition_NonPriority(p[j], proccessList, p), j);
                        proccessList.Insert(FindPosition_NonPriority(p[workedIndex], proccessList, p), workedIndex);
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                    else if (workedIndex < 0 && p_ap[j] == i && proccessList.Count == 0)
                        workedIndex = j;
                    else if (workedIndex < 0 && p_ap[j] == i && proccessList.Count != 0)
                    {
                        proccessList.Insert(FindPosition_NonPriority(p[j], proccessList, p), j);
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                    else if (workedIndex < 0 && p_ap[j] != i && proccessList.Count != 0)
                    {
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                }
                //PrintLine(FormArr(p, p_ap, i), workedIndex,procs);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void SJF_Disloge_Priority(int[] p_t, int[] p_app, int[] p_pr, List<Proc> procs)
        {
            foreach (var item in procs)
            {
                item.G = 0;
                item.I = 0;
            }
            var p = p_t.ToArray();
            var workedIndex = -1;
            var proccessList = new List<int>();
            for (var i = 0; p.Sum() != 0; i++)
            {
                for (var j = 0; j < p_ap.Length; j++)
                {
                    if (workedIndex >= 0 && p_ap[j] == i)
                    {
                        proccessList.Insert(FindPosition_Priority(p_pr[j], proccessList, p_pr), j);
                        proccessList.Insert(FindPosition_Priority(p_pr[workedIndex], proccessList, p_pr), workedIndex);
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                    else if (workedIndex < 0 && p_ap[j] == i && proccessList.Count == 0)
                        workedIndex = j;
                    else if (workedIndex < 0 && p_ap[j] == i && proccessList.Count != 0)
                    {
                        proccessList.Insert(FindPosition_Priority(p_pr[j], proccessList, p_pr), j);
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                    else if (workedIndex < 0 && p_ap[j] != i && proccessList.Count != 0)
                    {
                        workedIndex = proccessList.First();
                        proccessList.RemoveAt(0);
                    }
                }
                PrintLine(i, FormArr(p, p_ap, i), workedIndex, procs);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }


        static int FindPosition_NonPriority(int time, List<int> list, int[] p_t)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (time < p_t[list[i]])
                    return i;
            }
            return list.Count;
        }
        static int FindPosition_Priority(int prior, List<int> list, int[] p_p)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (prior <= p_p[list[i]])
                    return i;
            }
            return list.Count;
        }

        static int[] FormArr(int[] p, int[] p_ap, int time)
        {
            var result = new List<int>();
            for (var i = 0; i < p.Length; i++)
            {
                if (p[i] == 0 || time < p_ap[i])
                    result.Add(0);
                else
                    result.Add(1);
            }
            return result.ToArray();
        }
        static void PrintLine(int no, int[] p, int procNum, List<Proc> procs)
        {
            Proc.Capacity++;
            var line = no + "\t\b\b|";

            for (var i = 0; i < p.Length; i++)
            {
                if (p[i] == 0)
                    line += "   |";
                else if (procNum == i)
                {
                    procs[i].I++;

                    line += " И |";
                }

                else
                {
                    line += " Г |";
                    procs[i].G++;
                }
            }
            Console.WriteLine(line);
        }

        public static void Out(List<Proc> proc)
        {
            int sumBurst = 0;
            int sumIG = 0;
            StringBuilder countIG_str = new StringBuilder();
            StringBuilder countG_str = new StringBuilder();
            for (int i = 0; i < proc.Count; i++)
            {
                sumBurst += proc[i].BurstTime;

                countIG_str.Append($"p{i}={proc[i].I + proc[i].G} ");
                countG_str.Append($"p{i}={proc[i].G} ");
                sumIG += proc[i].I + proc[i].G;
            }

            Console.WriteLine($"Полное время выполнения всех процессов: {sumIG}");
            Console.WriteLine($"Время выполнения каждого процесса: {countIG_str}");
            Console.WriteLine($"Время ожидания каждого процесса: {countG_str}");
            Console.WriteLine($"Среднее время выполнения процесса: {(double)sumIG / proc.Count}");
            Console.WriteLine($"Среднее время ожидания процесса: { (double)proc.Sum(w => w.G) / proc.Count}");
        }
    }
}
