using System;
using System.Linq;
using System.Collections.Generic;

public static class PrimeFactors
{
    // 我多了一个循环去找出来素数。。。其实没有必要
    public static IEnumerable<long> Factors(long number)
    {
        var ret = new List<long>();
        for (int i = 2; i <= number; i++)
        {
            while (number % i == 0)
            {
                number /= i;
                ret.Add(i);
            }
        }

        return ret.ToArray();
    }
}