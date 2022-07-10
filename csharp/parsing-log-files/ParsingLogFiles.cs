using System;
using System.Text.RegularExpressions;
using System.Linq;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        return (new Regex(@"^\[(TRC|DBG|INF|ERR|INF|FTL)\]")).IsMatch(text);
    }

    public string[] SplitLogLine(string text)
    {
        return new Regex(@"<[-=^\*]+>").Split(text);
    }

    public int CountQuotedPasswords(string lines)
    {
        return new Regex("\"(.?)+(password)(.?)+\"", RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(lines).Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        return new Regex(@"end-of-line\d+").Replace(line, "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var regex = new Regex(@"(password(\w+))", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return lines.Select((a, index) =>
        {
            var m =  regex.Match(a);
            return m.Groups.Count > 1 ? $"{m.Groups[0].Value}: {a}" : $"--------: {a}";
        }).ToArray();
    }
}
