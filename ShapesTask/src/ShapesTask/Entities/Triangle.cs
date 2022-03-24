using ShapesTask.Entities.Abstractions;
using ShapesTask.Helpers;

namespace ShapesTask.Entities;

public class Triangle : ITriangle
{
    public Triangle(
        double sideA,
        double sideB,
        double sideC)
    {
        ValidationHelper.ThrowIfLessThanOrEqualTo(sideA, 0);
        ValidationHelper.ThrowIfLessThanOrEqualTo(sideB, 0);
        ValidationHelper.ThrowIfLessThanOrEqualTo(sideC, 0);

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
    public bool IsRightAngled {
        get
        {
            if (SideA > SideB && SideA > SideC)
            {
                return ApplyPythagoreanTheorem(SideA, SideB, SideC);
            }
            else if (SideB > SideC)
            {
                return ApplyPythagoreanTheorem(SideB, SideA, SideC);
            }
            else
            {
                return ApplyPythagoreanTheorem(SideC, SideA, SideB);
            }
        }
    }

    public double CalculateArea()
    {
        var perimeter = SideA + SideB + SideC;

        return Math.Sqrt(perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - SideC));
    }

    public static bool ApplyPythagoreanTheorem(double hypotenuse, double @base, double altitude)
    {
        return hypotenuse.Equals(Math.Sqrt(Math.Pow(@base, 2) + Math.Pow(altitude, 2)));
    }
}