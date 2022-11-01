using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var regOption = RegexOptions.None;
        if (HasFlag(flags, "-i"))
            regOption |= RegexOptions.IgnoreCase;

        if (HasFlag(flags, "-x"))
        {
            regOption |= RegexOptions.Multiline;
            pattern = $"^{pattern}$";
        }

        var reg = new Regex(pattern, regOption);

        var ret = new List<string>();
        foreach (var file in files)
        {
            var matches = File.ReadLines(file)
                .Select((text, index) => (text, index, reg.Match(text).Success))
                .Where(f => HasFlag(flags, "-v") ? !f.Success : f.Success)
                .Select(f =>
                {
                    if (HasFlag(flags, "-l"))
                    {
                        return file;
                    }

                    var lText = (HasFlag(flags, "-n") ? $"{f.index + 1}:" : "") + f.text;

                    return (files.Length > 1 ? file + ":" : "") + lText;
                }).Distinct();

            ret.AddRange(matches.ToList());
        }


        return string.Join("\n", ret);
    }

    private static bool HasFlag(string flags, string flag) => flags.Contains(flag);
}