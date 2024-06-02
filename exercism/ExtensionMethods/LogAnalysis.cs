using System.Text.RegularExpressions;
using DateTime = System.DateTime;

namespace Exercism.ExtensionMethods;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string substr)
    {
        var splitedString = str.Split(substr);
        
        if (splitedString[1].Length > 1 && !string.IsNullOrEmpty(splitedString[1])) return splitedString[1];
        
        if (splitedString[0].Length > 1 && !string.IsNullOrEmpty(splitedString[0])) return splitedString[0];
        
        return substr;
    }
    
    public static string SubstringBetween(this string str, string substr1, string substr2)
    {
        var pattern = $@"{Regex.Escape(substr1)}(.*?){Regex.Escape(substr2)}";
        return new Regex(pattern).Matches(str)[0].Groups[1].Value;
    }
    
    public static string Message(this string log) => log.Split("]:")[1].Trim();
    
    public static string LogLevel(this string log) => log.SubstringBetween("[", "]");
    
}

public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        var dateInMs = moment.Subtract(
            new DateTime(1970, 1, 1, 0, 0, 0)
        ).TotalMilliseconds + 1e9;
        
        Console.WriteLine(moment.AddMilliseconds(1e12));
        
       var date = (new DateTime(1970, 1, 1, 0, 0, 0)).AddMilliseconds(dateInMs + 10e9);
        return date; 
    }
}
//1303689600000
//1304689600000
