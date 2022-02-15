using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static int[] p_time = new int[] { 9, 2, 2, 3 };
        static int[] p_ap = new int[] { 3, 0, 0, 4 };
        static int[] p_pr = new int[] { 3, 1, 3, 3 };

        static void Main(string[] args)
        {
            Console.WriteLine("FCFS - прямой");
            FCFSForward(p_time);
            Console.WriteLine();

            Console.WriteLine("FCFS - обратно");
            FCFSBack(p_time);
            Console.WriteLine();

            Console.WriteLine("RR");
            RR(p_time, p_ap);
            Console.WriteLine();

            Console.WriteLine("SJF");
            SJF(p_time, p_ap);
            Console.WriteLine();

            Console.WriteLine("SJF с приоритетом");
            SJF_Prior(p_time, p_ap, p_pr.ToArray());
            Console.WriteLine();

            Console.WriteLine("SJF c вытиснением");
            SJF_Vit(p_time, p_ap, p_pr);
            Console.WriteLine(); 

            Console.WriteLine("SJF c вытиснением и приоритетом");
            SJF_Vit_Prior(p_time, p_ap, p_pr);
            Console.WriteLine();
            Console.ReadKey();
        }

        static void FCFSForward(int[] pt)
        {
            int[] procTime = new int[pt.Length];
            int[] idleTime = new int[pt.Length];
            idleTime[0] = 0;
            procTime[0] = pt[0];
            for (int i = 1; i < pt.Length; i++) {
                idleTime[i] = procTime[i - 1];
                procTime[i] = idleTime[i] + pt[i];
            }

            PrintTable(procTime.Sum(), procTime, idleTime);
        }

        static void FCFSBack(int[] pt)
        {
            int[] procTime = new int[pt.Length];
            int[] idleTime = new int[pt.Length];
            idleTime[pt.Length - 1] = 0;
            procTime[pt.Length - 1] = pt[pt.Length - 1];
            for (int i = pt.Length - 2; i >= 0; i--)
            {
                idleTime[i] = procTime[i + 1];
                procTime[i] = idleTime[i] + pt[i];
            }

            PrintTable(procTime.Sum(), procTime, idleTime);
        }

        static void RR(int[] pt, int[] pReady) {
            int[] time = pt.ToArray();
            int[] ready = pReady.ToArray();
            int[] procTime = new int[pt.Length];
            int[] idleTime = new int[pt.Length];
            int pointer = 0;
            bool stop = false;
            while(!stop) {
                if (time[pointer] > 0 && ready[pointer] < 1) {
                    for (int k = 0; k < 3; k++)
                    {
                        time[pointer]--;
                        procTime[pointer]++;
                        for (int i = 0; i < pt.Length; i++)
                        {
                            if (i != pointer && time[i] != 0)
                            {
                                idleTime[i]++;
                                ready[i]--;
                            }
                        }
                        if (time[pointer] == 0)
                            break;
                    }
                }
                stop = true;
                for (int i = 0; i < pt.Length; i++) {
                    if (time[i] > 0)
                    {
                        stop = false;
                        break;
                    }
                }
                if (pointer == pt.Length - 1)
                    pointer = 0;
                else
                    pointer++;
            }
            PrintTable(procTime.Sum(), procTime, idleTime);
        }

        static void SJF(int[] pt, int[] pReady) {
            int[] time = pt.ToArray();
            int[] procTime = new int[pt.Length];
            int[] idleTime = new int[pt.Length];
            int pointer = 0;

            int temp;
            for (int i = 0; i < time.Length - 1; i++)
            {
                for (int j = i + 1; j < time.Length; j++)
                {
                    if (time[i] > time[j])
                    {
                        temp = time[i];
                        time[i] = time[j];
                        time[j] = temp;
                    }
                }
            }

            while (pointer != (pt.Length))
            {
                while (time[pointer] != 0) {
                    time[pointer]--;
                    procTime[pointer]++;
                }

                for (int i = (pointer + 1); i < pt.Length; i++) {
                    procTime[i] = procTime[i - 1];
                    idleTime[i] = procTime[i - 1];
                }

                pointer++;
            }
            PrintTable(procTime.Sum(), procTime, idleTime);
        }

        static void SJF_Prior(int[] pt, int[] pReady, int[] prior)
        {
            int[] time = pt.ToArray();
            int[] ready = pReady.ToArray();
            int[] procTime = new int[pt.Length];
            int[] idleTime = new int[pt.Length];
            int pointer = 0;
            int count = 0;
            for (int i = 0; i < pt.Length; i++)
            {
                if (ready[i] < 1)
                {
                    pointer = i;
                    break;
                }
            }

            while (count != (pt.Length))
            {
                for (int i = 0; i < pt.Length; i++)
                {
                    if (prior[pointer] < prior[i] && ready[i] < 1) {
                        pointer = i;
                    }
                }
                while (time[pointer] != 0)
                {
                    time[pointer]--;
                    procTime[pointer]++;
                    for (int i = 0; i < pt.Length; i++)
                    {
                        if (i != pointer && prior[i] > 0)
                        {
                            procTime[i] = procTime[pointer];
                            idleTime[i] = procTime[pointer];
                            ready[i]--;
                        }
                    }
                }

                prior[pointer] = -1;
                count++;
            }
            PrintTable(procTime.Sum(), procTime, idleTime);
        }

        static void SJF_Vit(int[] pt, int[] pReady, int[] prior)
        {
            List<Proc> allProc = new List<Proc>();
            List<Proc> procList = new List<Proc>();
            int[] procTime = new int[pt.Length];
            int[] idleTime = new int[pt.Length];

            for (int i = 0; i < pt.Length; i++) {
                allProc.Add(new Proc
                {
                    idleTime = 0,
                    prior = prior[i],
                    procTime = 0,
                    timeLeft = pt[i],
                    ready = pReady[i]
                });
            }

            FindNextProc(allProc, procList);

            int pointer = 0;

            while (procList.Count != 0)
            {
                procList[0].InProcess();

                foreach (Proc i in procList.Skip(1)) {
                    i.Idle();
                }
                foreach (Proc i in allProc) {
                    //if (i.Ready <)
                    i.Idle();
                }

                if (procList[0].timeLeft < 1) {
                    procTime[pointer] = procList.First().procTime;
                    idleTime[pointer] = procList.First().idleTime;
                    procList.RemoveAt(0);
                    pointer++;
                }

                FindNextProc(allProc, procList);
            }
            PrintTable(procTime.Sum(), procTime, idleTime);
        }

        static void SJF_Vit_Prior(int[] pt, int[] pReady, int[] prior)
        {
            List<Proc> allProc = new List<Proc>();
            List<Proc> procList = new List<Proc>();
            int[] procTime = new int[pt.Length];
            int[] idleTime = new int[pt.Length];

            for (int i = 0; i < pt.Length; i++)
            {
                allProc.Add(new Proc
                {
                    idleTime = 0,
                    prior = prior[i],
                    procTime = 0,
                    timeLeft = pt[i],
                    ready = pReady[i]
                });
            }

            FindNextProcPrior(allProc, procList);

            int pointer = 0;

            while (procList.Count != 0)
            {
                procList[0].InProcess();

                foreach (Proc i in procList.Skip(1))
                {
                    i.Idle();
                }
                foreach (Proc i in allProc)
                {
                    i.Idle();
                }

                if (procList[0].timeLeft < 1)
                {
                    procTime[pointer] = procList.First().procTime;
                    idleTime[pointer] = procList.First().idleTime;
                    procList.RemoveAt(0);
                    pointer++;
                }

                FindNextProcPrior(allProc, procList);
            }
            PrintTable(procTime.Sum(), procTime, idleTime);
        }

        private static void FindNextProc(List<Proc> allProc, List<Proc> procList) {
            for (int i = 0; i < allProc.Count; i++)
            {
                if (allProc[i].ready < 1)
                {
                    if (procList.Count == 0)
                    {
                        procList.Add(allProc[i]);
                        allProc.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        int k = 0; bool check = true;
                        foreach (Proc j in procList)
                        {
                            if (j.timeLeft > allProc[i].timeLeft)
                            {
                                procList.Insert(k, allProc[i]);
                                allProc.RemoveAt(i);
                                i--;
                                check = false;
                                break;
                            }
                            k++;
                        }
                        if (check)
                        {
                            procList.Add(allProc[i]);
                            allProc.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }

        private static void FindNextProcPrior(List<Proc> allProc, List<Proc> procList)
        {
            for (int i = 0; i < allProc.Count; i++)
            {
                if (allProc[i].ready < 1)
                {
                    if (procList.Count == 0)
                    {
                        procList.Add(allProc[i]);
                        allProc.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        int k = 0; bool check = true;
                        foreach (Proc j in procList)
                        {
                            if (j.prior < allProc[i].prior)
                            {
                                procList.Insert(k, allProc[i]);
                                allProc.RemoveAt(i);
                                i--;
                                check = false;
                                break;
                            }
                            k++;
                        }
                        if (check)
                        {
                            procList.Add(allProc[i]);
                            allProc.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }

        static void PrintTable(int totalTime, int[] procTime, int[] idleTime) {
            Console.WriteLine("Полное время выполнения: " + totalTime);
            Console.WriteLine("Среднее время выполнения: " + (totalTime / procTime.Length));
            Console.WriteLine("Среднее время ожидания: " + (idleTime.Sum() / procTime.Length));
            Console.WriteLine(" |" + "В" + "|" + "О");
            Console.WriteLine("_____________________");
            for (var i = 0; i < procTime.Length; i++)
            {
                Console.WriteLine(i + "|" + procTime[i] + "|" + idleTime[i]);
                Console.WriteLine("_____________________");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
        }
    }
}