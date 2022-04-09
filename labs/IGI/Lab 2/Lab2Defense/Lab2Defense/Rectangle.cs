namespace Lab2Defense;

public class Rectangle
{
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public double Height { get; set; }
    public double Width { get; set; }
    public double Area => Height * Width;
    public double Perimeter => 2 * (Height + Width);
}