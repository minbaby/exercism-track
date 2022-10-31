using System;
using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var map = new Dictionary<int, string>()
        {
            {3, "Pling"},
            {5, "Plang"},
            {7, "Plong"},
        };
        var ret = map.Where(num => number % num.Key == 0)
            // .Aggregate(ret, (current, num) => current + num.Value)
            .Select(f => f.Value)
            .DefaultIfEmpty(number.ToString());

        return string.Concat(ret);
    }
}