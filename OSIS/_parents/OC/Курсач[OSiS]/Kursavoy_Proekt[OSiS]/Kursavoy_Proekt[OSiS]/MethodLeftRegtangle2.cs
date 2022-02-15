using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursavoy_Proekt_OSiS_
{
    class MethodLeftRegtangle2
    {
        public double RectangleY(double yNach, double yKon, double xNach, double xKon, double exactnessY, double exactnessX)
        {
            double SumY = 0;
            double h = (yKon - yNach) / exactnessY;
            for (double y = yNach; y < yKon; y += h)
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
            for (double x = xNach; x < xKon; x += h)
            {
                SumX += func(x, y, A, B, C, D);
            }
            return h * SumX;
        }
        public double func(double x, double y, double a, double b, double c, double d)
        {
            return a * Math.Pow(x, 2) + b * Math.Pow(y, 2) + c * Math.Sin(x) + d * Math.Cos(y);
        }
    }
}
