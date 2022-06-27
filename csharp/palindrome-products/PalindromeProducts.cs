using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    private static readonly Dictionary<(int, int), IEnumerable<IGrouping<int, (int a, int b, int)>>> Cached = new();

    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        var data = BuildPalindromeData(minFactor, maxFactor)
            .OrderByDescending(f => f.Key)
            .First();

        return (data.Key, (data.Select(f => (f.a, f.b))));
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        var data = BuildPalindromeData(minFactor, maxFactor)
            .OrderBy(f => f.Key)
            .First();

        return (data.Key, (data.Select(f => (f.a, f.b))));
    }

    private static Dictionary<int, IEnumerable<(int, int)>> BuildPalindromeData2(int minFactor, int maxFactor)
    {
        var ret = new Dictionary<int, IEnumerable<(int, int)>>();
        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                var values = i * j;
                if (!IsPalindrome(values))
                {
                    continue;
                }

                if (ret.TryGetValue(values, out var v))
                {
                    ret[values] = v.Append((i, j));
                }
                else
                {
                    ret[values] = Array.Empty<(int, int)>().Append((i, j));
                }
            }
        }

        if (ret.Count == 0)
        {
            throw new ArgumentException();
        }

        return ret;
    }


    private static IEnumerable<IGrouping<int, (int a, int b, int)>> BuildPalindromeData(int minFactor, int maxFactor)
    {
        if (Cached.ContainsKey((minFactor, maxFactor)))
        {
            return Cached[(minFactor, maxFactor)];
        }
        
        if (minFactor > maxFactor)
            throw new ArgumentException();

        var x = from a in Enumerable.Range(minFactor, maxFactor - minFactor + 1)
            from b in Enumerable.Range(minFactor, maxFactor - minFactor + 1)
            let val = a * b
            where IsPalindrome(val)
            select (a > b ? (b, a, val) : (a, b, val));

        var y = x.Distinct().GroupBy(f => f.Item3).ToArray();
        if (y.Length == 0)
            throw new ArgumentException();

        Cached[(minFactor, maxFactor)] = y;
        return y;
    }

    private static bool IsPalindrome(int value)
        => value.ToString().SequenceEqual(value.ToString().Reverse().ToArray());
}