namespace MathModule
{
    public interface IAreaCalculator
    {
        double A { get; set; }
        double B { get; set; }
        double C { get; set; }
        double Xn { get; set; }
        double Xk { get; set; }
        double Yn { get; set; }
        double Yk { get; set; }
        double N { get; set; }

        double CalculateSingleThread();
        double CalculateMultiThread(int threadsAmount);
    }
}
