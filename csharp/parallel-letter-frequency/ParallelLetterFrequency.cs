using System;
using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts) =>
        texts.AsParallel()
            .SelectMany(f => f.ToLower())
            .Where(char.IsLetter)
            .GroupBy(f => f)
            .Select(f => (f.Key, f.Count()))
            .ToDictionary(f => f.Key, f => f.Item2);
}