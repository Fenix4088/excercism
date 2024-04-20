using System.Text;
using System.Text.RegularExpressions;

namespace Exercism;

public class Identifier
{

    public static string ReplaceGreekLetter(string letter)
    {
        return Regex.Replace(letter, @"[α-ω]+", string.Empty);
    }
    
    public static string KebabCaseToCamelCase(string value)
    {
       return Regex.Replace(value, "-(.)", m => m.Groups[1].Value.ToUpper());
    }
    
    public static string RemoveNonLetterChars(string value)
    {
        return Regex.Replace(value, @"[^\p{L}_]", "");;
    }

    public static string Clean(string identifier)
    {
        var res =  KebabCaseToCamelCase(ReplaceGreekLetter(new StringBuilder(identifier).Replace(" ", "_").Replace("\0", "CTRL").ToString()));
        return RemoveNonLetterChars(res);
    }
}