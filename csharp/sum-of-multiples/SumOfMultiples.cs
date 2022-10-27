using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var yy = from x in Enumerable.Range(0, max)
                 from y in multiples
                 where y!= 0 && x % y == 0
                 select x;

        return yy.Distinct().Sum();
    }
}