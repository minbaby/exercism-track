using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var str = number.ToString();

        return number == str.Select(i => Math.Pow(i - '0', str.Length)).Sum();
    }
}