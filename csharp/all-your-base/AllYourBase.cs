using System;
using System.Linq;
using System.Collections.Generic;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1 || outputBase <= 1)
        {
            throw new ArgumentException();
        }

        if (inputDigits.Any(f => f >= inputBase || f < 0))
        {
            throw new ArgumentException();
        }

        var nums = inputDigits.Reverse().Select((n, i) => n * (int)Math.Pow(inputBase, i)).Sum();


        var ret = new List<int>();

        while (nums > 0)
        {
            var a = nums % outputBase;
            nums = nums / outputBase;
            ret.Add(a);
        }

        if (ret.Count == 0)
        {
            ret.Add(0);
        }
        else
        {
            ret.Reverse();
        }
        return ret.ToArray();
    }
}