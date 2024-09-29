namespace Exercism.Tuples;


public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string stringifiedNumber = number.ToString();
        int numberLength = stringifiedNumber.Length;
        return number == stringifiedNumber.Aggregate(0, (acc, next) => acc += (int)Math.Pow(Int32.Parse(next.ToString()), numberLength));
    }
}

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {

        for (int a = 1; a < sum / 2; a++)
        {
            for (int b = a; b < sum / 2; b++)
            {
                int c = sum - a - b;

                if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                {
                    yield return (a, b, c);
                }
                
            }
        }

    }
}