using System.Text.RegularExpressions;

namespace Exercism.Strings;

public class RunLengthEncoding
{
    public static string Encode(string input)
    {

        if (input == String.Empty || input == new string(input.Distinct().ToArray())) return input;
        
        var res = "";
        char prevLetter = input[0];
        var count = 1;

        for (var i = 1; i < input.Length; i++)
        {
            var currLetter = input[i];
            if (currLetter != prevLetter)
            {
                res += count > 1 ? $"{count}{prevLetter}" : prevLetter;
                count = 0;
                prevLetter = currLetter;
            }
            
            count++;
            if (i == input.Length - 1) res += count > 1 ? $"{count}{prevLetter}" : prevLetter;
        }
        

        return res;
    }

    public static string Decode(string input)
    {
        if (input == String.Empty || input.Distinct().All(char.IsLetter)) return input;
        var matches = new Regex(@"\d*\w|\w|\s*", RegexOptions.IgnoreCase).Matches(input);
        if (matches.Count <= 0) return input;
        
        var result = "";

        foreach (Match match in matches)
        {
            var matchedValue = match.Value;
            Console.WriteLine(matchedValue);

            if (matchedValue.Length > 1)
            {
                result += new string(matchedValue[^1], Int32.Parse(matchedValue[..^1]));
                continue;
            }

            if (int.TryParse(matchedValue, out int n))
            {
                result += " ";
                continue;
            }
            

            result += matchedValue;
        }
        
        return result;
    }
}