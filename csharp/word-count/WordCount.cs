using System;
using System.Collections.Generic;
using System.Linq;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase) =>
        phrase.Split(new[] { ',', ' ', '\n', '\t' },
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(f => string.Join("", f.ToLower().Where(c => char.IsLetterOrDigit(c) || c == '\'').Select(c => c)))
            .Select(f => f.Trim('\''))
            .GroupBy(f => f)
            .ToDictionary(f => f.Key, f => f.Count());
}