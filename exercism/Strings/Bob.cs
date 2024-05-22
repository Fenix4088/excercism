using System.Text.RegularExpressions;

namespace Exercism.Strings;

public class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();
        var isQuestion = statement.EndsWith("?");
        var isYell = statement.Equals(statement.ToUpper()) && new Regex("[a-zA-Z]").IsMatch(statement);
        var isSilence = statement.Equals(string.Empty);

        if (isYell && isQuestion) return "Calm down, I know what I'm doing!";
        else if (isQuestion) return "Sure.";
        else if (isYell) return "Whoa, chill out!";
        else if (isSilence) return "Fine. Be that way!";
        else return "Whatever.";
    }
}