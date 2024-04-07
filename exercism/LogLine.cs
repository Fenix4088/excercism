using System.Text.RegularExpressions;

namespace Exercism;

static class LogLine
{

    private static string[] SplitString(string str, string separator = ":")
    {
        if (str.Length <= 0) return [""];
        return str.Split(separator);
    }

    public static string Message(string logLine)
    {
        var splitted = SplitString($"{logLine}");
        if (splitted.Length > 1)
        {
            return splitted[1].Trim();
        }

        return splitted[0];
    }

    public static string LogLevel(string logLine) => new Regex(@"\[(\w+)\]").Match(logLine).Groups[1].Value.ToLower();

    public static string Reformat(string logLine) => $"{Message(logLine)} ({LogLevel(logLine)})";
}