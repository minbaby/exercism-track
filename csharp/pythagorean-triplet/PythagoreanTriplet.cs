using System;
using System.Collections.Generic;

// https://exercism.org/tracks/csharp/exercises/pythagorean-triplet
public static class PythagoreanTriplet
{

    // 直来直去就是这个思路，但是数字变大了，就会卡死，所以需要优化
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum_1(int sum)
    {
        var ret = new List<(int, int, int)>();
        for (int i = 1; i < sum; i++)
        {
            for (int j = i; j < sum; j++)
            {
                for (int k = j; k < sum; k++)
                {
                    if (i * i + j * j == k * k && i + j + k == sum)
                    {
                        ret.Add((i, j, k));
                    }
                }
            }
        }

        return ret.ToArray();
    }


    // 简单改了一下，最后一个无法通过
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum2(int sum)
    {
        var ret = new List<(int, int, int)>();
        for (int i = 1; i < sum; i++)
        {
            for (int j = i + 1; j < sum; j++)
            {
                for (int k = j + 1; k <= sum - j - i; k++)
                {
                    if (i + j + k == sum && i * i + j * j == k * k)
                    {
                        ret.Add((i, j, k));
                        Console.WriteLine("OK");

                    }
                }
            }
        }
        return ret.ToArray();
    }

    // 这个方法是OK的， IEnumerable 这种返回值的可以用yield 简化操作
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum3(int sum)
    {
        var ret = new List<(int, int, int)>();
        for (int i = 1; i < sum; i++)
        {
            for (int j = i + 1; j < sum; j++)
            {
                // 其实，当前两个数字确定的时候，第三个数字也确定了，因为三个数字的和为 sum， 所以可以少一个循环
                int k = sum - i - j;
                if (i * i + j * j == k * k)
                {
                    ret.Add((i, j, k));

                }
            }
        }
        return ret.ToArray();
    }

    // i < sum/3 (a^2 + b^2 = c^2)
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (int i = 1; i < sum; i++) // 这里应该是 i < sum/3 但是我无法推出这个逻辑
        {
            for (int j = i + 1; j < sum; j++) // 这里应该是 i < sum/2 但是我无法推出这个逻辑
            {
                // 其实，当前两个数字确定的时候，第三个数字也确定了，因为三个数字的和为 sum， 所以可以少一个循环
                int k = sum - i - j;
                if (j < k && i * i + j * j == k * k)
                {
                    yield return (i, j, k);
                }
            }
        }
    }
}