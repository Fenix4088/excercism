using System.Text.RegularExpressions;

namespace Exercism.Strings;

public class Acronym
{
    public static string Abbreviate(string phrase)
    {
        return new string(new Regex("-|_").Replace(phrase, " ").Split(" ").Where(word => word.Length > 0 && char.IsLetter(word[0]) ).Select(word => char.ToUpper(word[0])).ToArray());
    }
}