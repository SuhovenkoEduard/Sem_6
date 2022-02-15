using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursavoy_Proekt_OSiS_
{
    class Program
    {
        static void Main(string[] args)
        {
            double xNach = -40, xKon = 40, yNach = -80, yKon = 80;
            double stepX = (xKon - xNach) * 0.1;
            double stepY = (yKon - yNach) * 0.1;
            MethodLeftRegtangle Integr = new MethodLeftRegtangle();
            MethodLeftRegtangle2 Integr2 = new MethodLeftRegtangle2();
            Console.WriteLine("Интеграл равен: {0:f2}", Integr.RectangleY(yNach, yKon, xNach, xKon, stepY, stepX));
            Console.WriteLine("Интеграл равен: {0:f2}", Integr2.RectangleY(yNach, yKon, xNach, xKon, stepY, stepY));
            Console.ReadKey();
        }
    }
}
