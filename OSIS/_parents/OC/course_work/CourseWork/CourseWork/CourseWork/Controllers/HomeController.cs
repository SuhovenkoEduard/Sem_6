using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CourseWork.Filters;
using SurfaceLibrary;

namespace CourseWork.Controllers
{
    public class HomeController : Controller
    {
        Surface surface;
        Func<double, double, double, double, Func<double, double, double>, double> IntegralCalculationMethod;

        public HomeController(
            Surface surface, 
            Func<double, double, double, double, Func<double, double, double>, double> IntegralCalculationMethod)
        {
            this.surface = surface;
            this.IntegralCalculationMethod = IntegralCalculationMethod;
        }

        public IActionResult Index()
        {
            return View();
        }


        [PrepareFilter]
        public IActionResult GetPoints(double xSt, double xFin, double ySt, double yFin, double step = 1)
        {
            surface.SetIntervals(xSt, xFin, ySt, yFin, step);
        
            return Json(new
            {
                status = true,
                result = surface.GetPoints()
            });
        }

        [PrepareFilter]
        public IActionResult GetSurfaceArea(double xSt, double xFin, double ySt, double yFin, double step = 1)
        {
            List<(int threadsCount, long time, double surfaceArea)> results = new List<(int, long, double)>();
            Stopwatch stopwatch = new Stopwatch();

            surface.SetIntervals(xSt, xFin, ySt, yFin, step);
            
            for (int i = 1; i <= 10; i++)
            {
                stopwatch.Start();
                double area = surface.GetSurfaceArea(IntegralCalculationMethod, i);
                stopwatch.Stop();
                
                results.Add((i, stopwatch.Elapsed.Milliseconds, area));
                stopwatch.Reset();
            }

            return Json(new
            {
                status = true,
                result = results.Select(json => new
                {
                    json.threadsCount,
                    json.time,
                    json.surfaceArea
                })
            });
        }

    }
}
