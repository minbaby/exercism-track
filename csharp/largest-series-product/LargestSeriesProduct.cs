using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span > digits.Length || span < 0 || digits.Any(f => !char.IsDigit(f)))
        {
            throw new ArgumentException();
        }

        if (span == 0)
        {
            return 1;
        }

        return Enumerable.Range(0, digits.Length - (span - 1))
            .Select(i => digits.Substring(i, span)
                                .Select(c => long.Parse(c.ToString()))
                                .Aggregate((a, b) => a * b))
            .Max();
    }
}