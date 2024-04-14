namespace Exercism;

public class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) => (int)Math.Pow(Enumerable.Range(1, max).ToArray().Aggregate(0, (sum, next) => sum + next), 2);

    public static int CalculateSumOfSquares(int max) =>
        Enumerable.Range(1, max).ToArray().Aggregate(0, (sum, next) => sum + (int)Math.Pow(next, 2));

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}