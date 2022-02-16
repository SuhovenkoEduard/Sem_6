using System;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        private static StringBuilder buffer { get; set; }
        private static StringBuilder bufferMutex { get; set; }
        private static readonly string[] mats = new string[] { "123", "456", "789", "abc", "def", "ghi"};
        private static readonly int idleInSecondsX10 = 15;

        static Mutex mutex = new Mutex();
        static int x = 0;

        static void Main(string[] args)
        {
            Random rnd = new Random();

            buffer = new StringBuilder("");

            Console.WriteLine("Without mutex:");
            Thread first = new Thread(WriteDigitsToBuffer) { Name = "1st"};
            Thread second = new Thread(WriteLettersToBuffer) { Name = "2nd"};
            first.Start();
            second.Start();
            Thread.Sleep(idleInSecondsX10 * 400);
            Console.WriteLine("RESULT AFTER {0} seconds: {1}\n", idleInSecondsX10 * 0.4, buffer);

            bufferMutex = new StringBuilder("");
            Console.WriteLine("With mutex:");
            Thread third = new Thread(WriteDigitsToBufferMutex) { Name = "3rd" };
            Thread fourth = new Thread(WriteLettersToBufferMutex) { Name = "4th" };
            third.Start();
            fourth.Start();
            Thread.Sleep(idleInSecondsX10*400);
            Console.WriteLine("RESULT AFTER {0} seconds: {1}\n", idleInSecondsX10 * 0.4, bufferMutex);

            Console.ReadLine();
        }

        public static void WriteDigitsToBuffer()
        {
            Random rnd = new Random();
            int timeToSleep = rnd.Next(1, idleInSecondsX10) * 100;
            Console.WriteLine(Thread.CurrentThread.Name + " thread started its work");
            for(int a = 0; a < 3; a++)
            {
                buffer.Append(mats[a]);
                Console.WriteLine(string.Format("{0} thread wrote {1} and now sleeps for {2} s", Thread.CurrentThread.Name, mats[a], timeToSleep));
                Thread.Sleep(timeToSleep);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " thread finished its work");
        }

        public static void WriteDigitsToBufferMutex()
        {
            Random rnd = new Random();
            int timeToSleep = rnd.Next(1,idleInSecondsX10) * 100;
            mutex.WaitOne();
            Console.WriteLine(Thread.CurrentThread.Name + " thread started its work with locking mutex");
            for (int a = 0; a < 3; a++)
            {
                bufferMutex.Append(mats[a]);
                Console.WriteLine(string.Format("{0} thread wrote {1} and now sleeps for {2} s", Thread.CurrentThread.Name, mats[a], timeToSleep));
                Thread.Sleep(timeToSleep);
            }
            mutex.ReleaseMutex();
            Console.WriteLine(Thread.CurrentThread.Name + " thread finished its work with releasing mutex");
        }

        public static void WriteLettersToBuffer()
        {
            Random rnd = new Random();
            int timeToSleep = rnd.Next(1, idleInSecondsX10) * 100;
            Console.WriteLine(Thread.CurrentThread.Name + " thread started its work");
            for (int a = 3; a < 6; a++)
            {
                buffer.Append(mats[a]);
                Console.WriteLine(string.Format("{0} thread wrote {1} and now sleeps for {2} s", Thread.CurrentThread.Name, mats[a], timeToSleep));
                Thread.Sleep(timeToSleep);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " thread finished its work");
        }
        public static void WriteLettersToBufferMutex()
        {
            Random rnd = new Random();
            int timeToSleep = rnd.Next(idleInSecondsX10) * 100;
            mutex.WaitOne();
            Console.WriteLine(Thread.CurrentThread.Name + " thread started its work with locking mutex");
            for (int a = 3; a < 6; a++)
            {
                bufferMutex.Append(mats[a]);
                Console.WriteLine(string.Format("{0} thread wrote {1} and now sleeps for {2} s", Thread.CurrentThread.Name, mats[a], timeToSleep));
                Thread.Sleep(timeToSleep);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " thread finished its work with releasing mutex");
            mutex.ReleaseMutex();
        }
    }
}
