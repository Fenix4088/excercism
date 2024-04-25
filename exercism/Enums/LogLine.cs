using System.Text.RegularExpressions;

namespace Exercism.Enums;

enum LogLevel 
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info  = 4,
    Warning = 5,
    Error  = 6,
    Fatal  = 42

}

static class LogLine
{

    private static Dictionary<string, LogLevel> logLevelList = new Dictionary<string, LogLevel>
    {
        { "trc", LogLevel.Trace },
        { "dbg", LogLevel.Debug },
        { "inf", LogLevel.Info },
        { "wrn", LogLevel.Warning },
        { "err", LogLevel.Error },
        { "ftl", LogLevel.Fatal },
    };
    public static LogLevel ParseLogLevel(string logLine)
    {

        try
        {
            var logLevel = new Regex(@"\[(\w+)\]").Match(logLine).Groups[1].Value.ToLower();

            return logLevelList[logLevel];
        }
        catch (Exception e)
        {
            return LogLevel.Unknown;
        }

    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
}