using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SurfaceLibrary
{
    public class Surface
    {
        protected double a { get; set; }
        protected double b { get; set; }
        protected double c { get; set; }
        protected double d { get; set; }

        public double XSt { get; set; }
        public double XFin { get; set; }
        public double YSt { get; set; }
        public double YFin { get; set; }

        public double Step { get; set; }

        public Surface(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public void SetIntervals(double xSt, double xFin, double ySt, double yFin, double step)
        {
            XSt = xSt;
            XFin = xFin;
            YSt = ySt;
            YFin = yFin;
            Step = step;
        }

        public double GetSurfaceArea(Func<double, double, double, double, Func<double, double, double>, double> methodForCalculateIntegral, int maxCountThreads = 1000)
        {
            double x1 = XSt;
            double x2 = x1 + Step;
            int countThreads = 0;
            List<Task<double>> tasks = new List<Task<double>>();

                    
            while (x1 < XFin)
            {              
                var t = new Task<double>((state) =>
                {
                    double localX1 = (state as (double, double)?).Value.Item1;
                    double localX2 = (state as (double, double)?).Value.Item2;

                    double s = 0;
                    double y1 = YSt;
                    double y2 = y1 + Step;

                    while (y1 < YFin)
                    {
                        localX2 = localX2 > XFin ? XFin : localX2;
                        y2 = y2 > YFin ? YFin : y2;

                        s += methodForCalculateIntegral(localX1, localX2, y1, y2, InitialFunction);                         

                        y1 += Step;
                        y2 += Step;
                    }


                    Interlocked.Decrement(ref countThreads);                 
                    return s;
                }, (x1, x2));


                // Simple spinlock
                while (countThreads >= maxCountThreads)
                {
                    Thread.Sleep(1);
                }
                countThreads++;

                t.Start();
                tasks.Add(t);

                x1 += Step;
                x2 += Step;
            }

            Task.WaitAll(tasks.ToArray());
            return tasks.Select(x => x.Result).Sum();
        }


        /// <summary>
        ///     <para>Method for calculate area of surface</para>
        ///     <para>Return IEnumerable of Point. Point = { x, y, z }</para>
        /// </summary>
        public IEnumerable<Point> GetPoints()
        {
            double xTemp = XSt;
            List<Task<List<Point>>> tasks = new List<Task<List<Point>>>();

            while (xTemp <= XFin)
            {
                var t = new Task<List<Point>>((stateX) =>
                {
                    double localX = (double)stateX;
                    double yTemp = YSt;
                    List<Point> localPoints = new List<Point>();

                    while (yTemp < YFin)
                    {
                        localPoints.Add(new Point { Z = DerivativeOfFuncion(localX, yTemp) });
                        yTemp += Step;
                    }
                    localPoints.Add(new Point { Z = DerivativeOfFuncion(localX, yTemp) });

                    return localPoints;
                }, xTemp);

                t.Start();
                tasks.Add(t);

                xTemp += Step;
            }

            Task.WaitAll(tasks.ToArray());

            var points = tasks
                .Select(t => t.Result)
                .Aggregate((x, y) =>
                {
                    x.AddRange(y.AsEnumerable());
                    return x;
                })
                .OrderBy(p => p.X)
                .ThenBy(p => p.Y);

            return points;
        }


        public virtual double InitialFunction(double x, double y)
        {
            return Math.Sqrt(1 +
                            Math.Pow(2 * a * x + c * Math.Exp(-x), 2) +
                            Math.Pow(2 * b * y + d * Math.Exp(-y), 2));
        }


        /// <summary>
        ///     Rule for calculate coordinate Z by X,Y.
        /// </summary>
        public virtual double DerivativeOfFuncion(double x, double y)
        {   
            return a * Math.Pow(x, 2) +
                    b * Math.Pow(y, 2) +
                    c * Math.Exp(-x) +
                    d * Math.Exp(-y);
        }

    }

}
