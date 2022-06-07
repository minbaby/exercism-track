using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var val = Enumerable.Range(0, max+1).Sum();
        return val * val;
    }

    public static int CalculateSumOfSquares(int max)
    {
        return Enumerable.Range(0, max+1).Sum(f => f * f);
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}