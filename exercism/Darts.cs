namespace Exercism;

// 
// In general, x and y must satisfy (x - center_x)² + (y - center_y)² < radius².
// 

public class Darts
{
    public static int Score(double x, double y)
    {
        if (IsLandsIntoTarget(x, y, 1)) return 10;
        else if (IsLandsIntoTarget(x, y, 5)) return 5;
        else if (IsLandsIntoTarget(x, y, 10)) return 1;
        else return 0;
    }

    private static bool IsLandsIntoTarget(double x, double y, int radius = 10) =>
        Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(radius, 2);
}