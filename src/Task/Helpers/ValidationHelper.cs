namespace Task.Helpers;

public class ValidationHelper
{
    public static void ThrowIfLessThan(double value, double minValue)
    {
        if (value < minValue)
            throw new ArgumentOutOfRangeException(nameof(value), $"Value cannot be less than {minValue}");
    }
    public static void ThrowIfLessThanOrEqualTo(double value, double minValue)
    {
        if (value <= minValue)
            throw new ArgumentOutOfRangeException(nameof(value), $"Value cannot be less than or equal to {minValue}");
    }
}