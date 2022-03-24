using Task.Entities.Abstractions;
using Task.Helpers;

namespace Task.Entities;

public class Circle : ICircle
{
    public Circle(double radius)
    {
        ValidationHelper.ThrowIfLessThan(radius, 0);

        Radius = radius;
    }

    public double Radius { get; set; }

    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}