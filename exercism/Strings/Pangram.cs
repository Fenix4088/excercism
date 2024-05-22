namespace Exercism.Strings;

public class Pangram
{
    public static bool IsPangram(string input)
    {
        
        return input.ToLower().Where(char.IsLetter).Distinct().ToArray().Length == 26;
    }
}