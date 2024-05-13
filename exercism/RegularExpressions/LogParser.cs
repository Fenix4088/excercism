using System.Text.RegularExpressions;

namespace Exercism.RegularExpressions;

public class LogParser
{
    
    private Regex ValidaLinePattern { get; } = new Regex(@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\].+");

    private Regex LogLinePattern { get; } = new Regex(@"\<[\^\*\=\-]*\>");
    private Regex CountQuotedPasswordsPattern { get; } = new Regex("\".*password.*\"", RegexOptions.IgnoreCase);    
    private Regex ListLinesWithPasswordsPattern { get; } = new Regex(@"\bpassword\w*", RegexOptions.IgnoreCase);    
    private readonly string weakPasswordRegexPattern = @"password\w+";
    
    
    public bool IsValidLine(string text) => this.ValidaLinePattern.IsMatch(text);

    public string[] SplitLogLine(string text) => this.LogLinePattern.Split(text);

    public int CountQuotedPasswords(string lines) => this.CountQuotedPasswordsPattern.Matches(lines).Count;

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d*", "");

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var processedLines = new List<string>();
        foreach(string line in lines)
        {
            Match passwordMatch = Regex.Match(line, weakPasswordRegexPattern, RegexOptions.IgnoreCase);
            if (passwordMatch == Match.Empty)
                processedLines.Add($"--------: {line}");
            else 
                processedLines.Add($"{passwordMatch.Value}: {line}");
        }
        return processedLines.ToArray();
    }
}