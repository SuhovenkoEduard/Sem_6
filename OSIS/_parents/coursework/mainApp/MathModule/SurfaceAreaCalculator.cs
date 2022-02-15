using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathModule
{
    public class SurfaceAreaCalculator : IAreaCalculator
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Xn { get; set; }
        public double Xk { get; set; }
        public double Yn { get; set; }
        public double Yk { get; set; }
        public double N { get; set; }

        public SurfaceAreaCalculator()
        {
            A = -3; 
            B = 1;
            C = -5;
            Xn = -40;
            Xk = 40;
            Yn = -80;
            Yk = 80;
            N = 1000;
        }

        public SurfaceAreaCalculator(double paramA, double paramB, double paramC, double paramXn, double paramXk, double paramYn, double paramYk, double paramN)
        {
            A = paramA;
            B = paramB;
            C = paramC;
            Xn = paramXn;
            Xk = paramXk;
            Yn = paramYn;
            Yk = paramYk;
            N = paramN;
        }

        public double hx => (Xk - Xn) / N;
        public double hy => (Yk - Yn) / N;

        public double XDerivativefunction(double x, double y)
            => A + C * Math.Cos(y) * Math.Cos(x);

        public double YDerivativefunction(double x, double y)
            => B - C * Math.Sin(x) * Math.Sin(y);

        public double Integrand(double x, double y)
        {
            double dx = XDerivativefunction(x, y), dy = YDerivativefunction(x, y);
            return Math.Sqrt(1 + dx * dx + dy * dy);
        }

        public double CalculateSingleThread()
        {
            double x, y;
            double sum = 0;
            List<double> xlist = new List<double>();
            List<double> values = new List<double>();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (x = Xn + hx; x <= Xk; x += hx)
            {
                for (y = Yn + hy; y <= Yk; y += hy)
                {
                    sum += Integrand(x, y);
                }
            }
            sw.Stop();

            sum *= hx;
            sum *= hy;

            using (StreamWriter sWriter = new StreamWriter("Stats\\1threadsResult.txt", false))
            {
                sWriter.Flush();
                sWriter.WriteLine(sum + "$" + sw.Elapsed.TotalSeconds);
            }

            return sum;
        }

        public double CalculateMultiThread(int threadsAmount)
        {
            string filePath = "Stats\\" + threadsAmount + "stats.txt";

            object lockObject = new object();
            int j;

            Stopwatch sw = new Stopwatch();

            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
            }

            Parallel.For(1, (int) N + 1, new ParallelOptions { MaxDegreeOfParallelism = threadsAmount }, i =>
            {
                double x, y, sum = 0;
                sw.Reset();
                sw.Start();
                sum = 0;
                x = Xn + i * hx;
                for (y = Yn + hy; y <= Yk; y += hy)
                {
                    sum += Integrand(x, y);
                }
                sw.Stop();

                lock (lockObject)
                {
                    using (StreamWriter sWriter = new StreamWriter(filePath, true))
                    {
                        sWriter.WriteLine(Xn + i * hx + "$" + sum + "$" + sw.Elapsed.TotalSeconds);
                    }
                }
            });

            string line;
            double time = 0;
            double answer = 0;

            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    answer += double.Parse((line.Split('$'))[1]);
                    time += double.Parse((line.Split('$'))[2]);
                }
            }
            answer *= hx;
            answer *= hy;

            using (StreamWriter sWriter = new StreamWriter("Stats\\" + threadsAmount + "threadsResult.txt"))
            {
                sWriter.WriteLine(answer + "$" + time);
            }

            return (answer);

        }
    }
}
