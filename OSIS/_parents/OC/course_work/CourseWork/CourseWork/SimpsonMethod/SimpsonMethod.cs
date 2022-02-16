using System;

namespace SimpsonMethodLibrary
{
    public class SimpsonMethod
    {
        public double Calculate(double xSt, double xFin, double ySt, double yFin, Func<double, double, double> f)
        {
            return (xFin - xSt) / 6 * (yFin - ySt) / 6 * 
                   (f(xSt, ySt) + 4 * f((xSt + xFin) / 2, ySt) + 
                   f(xFin, ySt) + 4 * (f(xSt, (ySt + yFin) / 2) + 4 * 
                   f((xSt + xFin) / 2, (ySt + yFin) / 2) + f(xFin, (ySt + yFin) / 2)) +
                   f(xSt, yFin) + 4 * f((xSt + xFin) / 2, yFin) + f(xFin, yFin));
        }
    }
}
