using ShapesTask.Entities.Abstractions;
using ShapesTask.Helpers;

namespace ShapesTask.Entities;

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