using System;
using System.Linq;

public static class Hamming
{
    public static int Distance1(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException();
        }

        int sum = 0;

        for (int i = 0; i < firstStrand.Length; i++)
        {
            if (firstStrand[i] != secondStrand[i])
            {
                sum++;
            }
        }

        return sum;
    }


    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException();
        }

        // 组合成一个 tuple， 然后 count 两个不相等的个数
        return firstStrand.Zip(secondStrand).Count(tuple => tuple.First != tuple.Second);
    }
}