using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        var x = D(minFactor, maxFactor);

        (int, IEnumerable<(int, int)>) ret = new()
        { Item1 = int.MinValue, Item2 = Array.Empty<(int, int)>() };

        foreach (var (k, v) in x)
        {
            if (k >= ret.Item1)
            {
                ret.Item1 = k;
                ret.Item2 = v;
            }
        }

        return ret;
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        var x = D(minFactor, maxFactor);

        (int, IEnumerable<(int, int)>) ret = new()
        { Item1 = int.MaxValue, Item2 = Array.Empty<(int, int)>() };

        foreach (var (k, v) in x)
        {
            if (k <= ret.Item1)
            {
                ret.Item1 = k;
                ret.Item2 = v;
            }
        }

        return ret;
    }

    private static Dictionary<int, IEnumerable<(int, int)>> D(int minFactor, int maxFactor)
    {
        var ret = new Dictionary<int, IEnumerable<(int, int)>>();
        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                var values = i * j;
                if (IsPalindrome(values))
                {
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
        }

        if (ret.Count == 0) {
            throw new ArgumentException();
        }

        return ret;
    }

    private static bool IsPalindrome(int value)
        => value.ToString() == new string(value.ToString().Reverse().ToArray());
}
