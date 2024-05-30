namespace Exercism.IfStattements;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length) throw new ArgumentException();
        if (firstStrand == secondStrand) return 0;

        var count = 0;
        for (var  i = 0; i < firstStrand.Length; i++)
        {
            if (firstStrand[i] != secondStrand[i])
            {
                count++;
            }
        }

        return count;
    }
}