namespace Exercism.forLoop;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        
        int numbersLength = numbers.Length;

        if (sliceLength > numbersLength || sliceLength <= 0) throw new ArgumentException();
        
        List<string> result = new List<string>{};
        
        if (numbersLength <= sliceLength)
        {
            result.Add(numbers);
            return result.ToArray();
        }

        for (var i = 0; i < numbersLength; i++)
        {
            if (i + sliceLength > numbersLength) break;

            result.Add(numbers.Substring(i, sliceLength));
        }

        return result.ToArray();
    }
}