using System;

public static class Grains
{

    public static ulong Square(int n)
    {
        if (n <= 0 || n > 64)
        {
            throw new ArgumentOutOfRangeException();
        }

        return (ulong)1 << (n - 1);
    }

    /// 0-64( 2^0 + .... + 2^64)
    /// ulong => 64bit
    public static ulong Total()
    {
        return ulong.MaxValue;
    }

    private static ulong TotalNum = 0;
    public static ulong Square2(int n)
    {
        if (n <= 0 || n > 64)
        {
            throw new ArgumentOutOfRangeException();
        }

        var lastNum = 0UL;
        for (int i = 0; i < n; i++)
        {
            if (lastNum == 0)
            {
                lastNum = 1;
                TotalNum = 1;
            }
            else
            {
                lastNum *= 2;
                TotalNum += lastNum;
            }
        }


        return lastNum;
    }

    public static ulong Total2()
    {
        Square(64);
        return TotalNum;
    }
}