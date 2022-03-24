using System;
using NUnit.Framework;
using ShapesTask.Entities;
using ShapesTask.Entities.Abstractions;

namespace ShapesTaskTests;

[TestFixture]
public class ShapeTests
{
    [Test]
    public void CalculateArea_ShapeUnknownOnCompileTime_ReturnsSameResultAsWhenItIsKnown()
    {
        var circle = new Circle(2);
        var triangle = new Triangle(4, 5, 6);

        var shapes = new IShape[]
        {
            circle,
            triangle,
        };

        var circleResult = circle.CalculateArea();
        var triangleResult = triangle.CalculateArea();

        var unknownShapeResult1 = shapes[0].CalculateArea();
        var unknownShapeResult2 = shapes[1].CalculateArea();

        Assert.AreEqual(circleResult, unknownShapeResult1);
        Assert.AreEqual(triangleResult, unknownShapeResult2);
    }

    public void Circle_RadiusLessThan0_ThrowsArgumentOutOfRangeException()
    {
        void CreateCircle() => new Circle(-1);
        Assert.Throws<ArgumentOutOfRangeException>(CreateCircle);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(5)]
    public void Circle_CalculateArea_ReturnsCorrectResult(double radius)
    {
        var expectedArea = Math.PI * Math.Pow(radius, 2);
        var area = new Circle(radius).CalculateArea();
        Assert.AreEqual(expectedArea, area);
    }

    [TestCase(0, 1, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(1, 1, 0)]
    [TestCase(-1, 1, 1)]
    [TestCase(1, -1, 1)]
    [TestCase(1, 1, -1)]
    public void Triangle_SideLessThanOrEqualTo0_ThrowsArgumentOutOfRangeException(double sideA, double sideB, double sideC)
    {
        void CreateTriangle() => new Triangle(sideA, sideB, sideC);
        Assert.Throws<ArgumentOutOfRangeException>(CreateTriangle);
    }

    [TestCase(1, 2, 3)]
    [TestCase(4, 4, 4)]
    public void Triangle_CalculateArea_ReturnsCorrectResult(double sideA, double sideB, double sideC)
    {
        var perimeter = sideA + sideB + sideC;
        var expectedArea = Math.Sqrt(perimeter * (perimeter - sideA) * (perimeter - sideB) * (perimeter - sideC));
        var area = new Triangle(sideA, sideB, sideC).CalculateArea();
        Assert.AreEqual(expectedArea, area);
    }

    [TestCase(5, 4, 3)]
    [TestCase(4, 4, 4)]
    public void Triangle_IsRightAngled_ReturnsCorrectResult(double hypotenuse, double @base, double altitude)
    {
        var expectedResult = hypotenuse.Equals(Math.Sqrt(Math.Pow(@base, 2) + Math.Pow(altitude, 2)));
        var result = new Triangle(hypotenuse, @base, altitude).IsRightAngled;
        Assert.AreEqual(expectedResult, result);
    }
}