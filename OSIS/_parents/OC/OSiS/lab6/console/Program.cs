using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProccessPlanning
{
    class Program
    {
        static int[] p_t = new int[] { 10, 3, 3, 7 };
        static int[] p_ap = new int[] { 2, 0, 4, 5 };
        static int[] p_pr = new int[] { 1, 3, 3, 2 };
        static void Main(string[] args)
        {
            Console.WriteLine("FCFS - прямой");
            FCFS_DIRECT(p_t, p_ap);
            Console.WriteLine();

            Console.WriteLine("FCFS - обратный");
            FCFS_BACK(p_t, p_ap);
            Console.WriteLine();

            Console.WriteLine("RR");
            RR(p_t, p_ap);
            Console.WriteLine();

            Console.WriteLine("SJF невытесняющий, без приоритета");
            SJF_NON_DISLOGE_NON_PRIORITY(p_t, p_ap);
            Console.WriteLine();

            Console.WriteLine("SJF невытесняющий, с приоритетом");
            SJF_NON_DISLOGE_PRIORITY(p_t, p_ap, p_pr);
            Console.WriteLine();

            Console.WriteLine("SJF вытесняющий, без приоритета");
            SJF_DISLOGE_NON_PRIORITY(p_t, p_ap);
            Console.WriteLine();

            Console.WriteLine("SJF вытесняющий, с приоритетом");
            SJF_DISLOGE_PRIORITY(p_t, p_ap, p_pr);
            Console.WriteLine();
        }

        static void FCFS_DIRECT(int[] p_t, int[] p_app)
        {
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
                PrintLine(FormArr(p, p_ap, i), workedIndex);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void FCFS_BACK(int[] p_t, int[] p_app)
        {
            var p = p_t.ToArray();
            var workedIndex = -1;
            var proccessStack = new Stack<int>();
            for (var i = 0; p.Sum() != 0; i++)
            {
                for (var j = p_ap.Length - 1; j >= 0; j--)
                {
                    if (workedIndex >= 0 && p_ap[j] == i)
                        proccessStack.Push(j);
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
                PrintLine(FormArr(p, p_ap, i), workedIndex);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void RR(int[] p_t, int[] p_app)
        {
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
                PrintLine(FormArr(p, p_ap, i), workedIndex);
                if(workedIndex >= 0)
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

        static void SJF_NON_DISLOGE_NON_PRIORITY(int[] p_t, int[] p_app)
        {
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
                PrintLine(FormArr(p, p_ap, i), workedIndex);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void SJF_NON_DISLOGE_PRIORITY(int[] p_t, int[] p_app, int[] p_pr)
        {
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
                PrintLine(FormArr(p, p_ap, i), workedIndex);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void SJF_DISLOGE_NON_PRIORITY(int[] p_t, int[] p_app)
        {
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
                PrintLine(FormArr(p, p_ap, i), workedIndex);
                if (workedIndex >= 0)
                {
                    p[workedIndex]--;
                    if (p[workedIndex] == 0)
                        workedIndex = -1;
                }
            }
        }

        static void SJF_DISLOGE_PRIORITY(int[] p_t, int[] p_app, int[] p_pr)
        {
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
                PrintLine(FormArr(p, p_ap, i), workedIndex);
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
            for(var i = 0; i < p.Length; i++)
            {
                if (p[i] == 0 || time < p_ap[i])
                    result.Add(0);
                else
                    result.Add(1);
            }
            return result.ToArray();
        }
        static void PrintLine(int[] p, int procNum)
        {
            var line = "|";
            for(var i = 0; i < p.Length; i++)
            {
                if (p[i] == 0)
                    line += "   |";
                else if (procNum == i)
                    line += " И |";
                else
                    line += " Г |";
            }
            Console.WriteLine(line);
            Console.WriteLine("-----------------");
        }
    }
}
