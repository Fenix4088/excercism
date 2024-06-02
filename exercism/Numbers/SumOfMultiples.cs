using System.Runtime.InteropServices.JavaScript;

namespace Exercism.Numbers;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {

        var res = multiples.Where(n => n > 0)
            .SelectMany(num => Enumerable.Range(1, (max - 1) / num).Select(i => i * num))
            .ToHashSet();

        return res.Sum();
    }
}