namespace Exercism.Numbers;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    private static int CalcAliquotSum(int number)
    {
        var properDivision = GetProperDivisors(number);
        return properDivision.Count <= 0 ? 0 : properDivision.Sum();
    }

    private static List<int> GetProperDivisors(int number)
    {
        var res = new List<int>();

        for (int i = 1; i < number; i++)
        {
            if (number % i == 0) res.Add(i);
        }

        return res;
    }
    

    public static Classification Classify(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException();
        
        var aliquotSum = CalcAliquotSum(number);

        return aliquotSum switch
        {
            _ when aliquotSum == number => Classification.Perfect,
            _ when aliquotSum > number => Classification.Abundant,
            _ => Classification.Deficient
        };
    }
    
    // public static Classification Classify(int number) =>
    //     (Classification)Enumerable.Range(1, number - 1).Where(i => number % i == 0).Sum().CompareTo(number);
}