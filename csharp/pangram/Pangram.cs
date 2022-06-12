using System;
using System.Linq;

public static class Pangram
{
    // 这个写法不是最简的，存在优化的空间
    public static bool IsPangram1(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        input = input.ToLower();
        for (int i = 'a'; i <= 'z'; i++)
        {
            if (!input.Contains((char)i))
            {
                return false;
            }
        }

        return true;
    }


    public static bool IsPangram(string input)
    {
        return "abcdefghijklmnopqrstuvwxyz".All(input.ToLower().Contains);
    }
}
