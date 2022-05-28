using System;
using System.Text.RegularExpressions;

static class LogLine
{
    public static string Message(string logLine)
    {
        var r = new Regex(@"\[(?<level>.+)\]:(?<msg>.+)");
        var result = r.Matches(logLine);
        return result[0].Groups[2].Value.Trim();
    }

    public static string LogLevel(string logLine)
    {
        var r = new Regex(@"\[(?<level>.+)\]:(?<msg>.+)");
        var result = r.Matches(logLine);
        return result[0].Groups[1].Value.ToLower();
    }

    public static string Reformat(string logLine)
    {
        var r = new Regex(@"\[(?<level>.+)\]:(?<msg>.+)");
        var result = r.Matches(logLine);
        return $"{result[0].Groups[2].Value.Trim()} ({result[0].Groups[1].Value.ToLower()})";
    }
}
