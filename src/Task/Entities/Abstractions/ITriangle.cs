namespace Task.Entities.Abstractions;

public interface ITriangle : IShape
{
    double SideA { get; set; }
    double SideB { get; set; }
    double SideC { get; set; }

    bool IsRightAngled { get; }
}