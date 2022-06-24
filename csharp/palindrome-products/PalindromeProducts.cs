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

        foreach (var (k, value) in x)
        {
            if (value >= ret.Item1)
            {
                ret.Item1 = value;
                ret.Item2 = ret.Item2.Append(k);
            }
        }

        return ret;
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        var x = D(minFactor, maxFactor);

        (int, IEnumerable<(int, int)>) ret = new()
            { Item1 = int.MaxValue, Item2 = Array.Empty<(int, int)>() };

        foreach (var (k, value) in x)
        {
            if (value <= ret.Item1)
            {
                ret.Item1 = value;
                ret.Item2 = ret.Item2.Append(k);
            }
        }

        return ret;
    }

    private static Dictionary<(int, int), int> D(int minFactor, int maxFactor)
    {
        var list = new Dictionary<(int, int), int>();
        for (int i = minFactor; i < maxFactor; i++)
        {
            for (int j = i; j < maxFactor; j++)
            {
                if (IsPalindrome(i * j))
                {
                    list.Add((i, j), i * j);
                }
            }
        }

        return list;
    }

    private static bool IsPalindrome(int value)
        => value.ToString() == new string(value.ToString().Reverse().ToArray());
}