namespace Exercism.IfStattements;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException();
        
        var count = 0;
        while (number != 1)
        {
            if (int.IsEvenInteger(number))
            {
                number = number / 2;
            }
            else
            {
                number = (number * 3) + 1;
            }

            count++;
        }

        return count;
    }
}