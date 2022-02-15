using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursavoy_Proekt_OSiS_
{
    class MethodLeftRegtangle
    {
        public double RectangleY(double yNach, double yKon, double xNach, double xKon, double exactnessY, double exactnessX)
        {
            double SumY = 0;
            double h = (yKon - yNach) / exactnessY;
            for(double y = yNach; y < yKon; y += h)
            {
                SumY += RectangleX(y, xNach, xKon, exactnessX);
            }
            return h * SumY;
        }
        public double RectangleX(double y, double xNach, double xKon, double exactnessX)
        {
            double SumX = 0;
            double A = 3, B = 1, C = 1, D = 1;
            double h = (xKon - xNach) / exactnessX;
            for(double x = xNach; x < xKon; x += h)
            {
                SumX += func(x, y, A, B, C, D);
            }
            return h * SumX;
        }
        public double func(double x, double y, double a, double b, double c, double d)
        {
            return Math.Sqrt(1 + Math.Pow(ZfuncPoX(x, a, c), 2) + Math.Pow(ZfuncPoY(y, b, d), 2));
        }

        public double ZfuncPoX(double x, double a, double c)
        {
            return a * 2 * x + c * Math.Cos(x);
        }
        public double ZfuncPoY(double y, double b, double d)
        {
            return b * 2 * y - d * Math.Sin(y);
        }
    }
}
