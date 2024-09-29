namespace Exercism.Arrays;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if(inputBase <= 0 || outputBase <= 0) throw new ArgumentException();
        
        List<int> res = new List<int> { };

        return res.ToArray();
    }
}