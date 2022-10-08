using System.Collections.Generic;
using System.Linq;
using System;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

// 这个看起来像是，先找出所有的约数，然后求和比较
public static class PerfectNumbers
{
    // 30
    // 1 2 3 5 6 10 15
    public static Classification Classify(int number)
    {

        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var list = new List<int>();

        var max = Math.Sqrt(number);
        for (int i = 1; i < max; i++)
        {
            if (list.Contains(i))
            {
                continue;
            }

            if (number % i == 0)
            {
                list.Add(i);
                list.Add(number / i);
            }
        }

        var num = list.Distinct().Sum() - number;

        return num switch
        {

            _ when num == number => Classification.Perfect,
            _ when num > number => Classification.Abundant,
            _ when num < number => Classification.Deficient,
            _ => throw new ArgumentException(),
        };


    }
}
