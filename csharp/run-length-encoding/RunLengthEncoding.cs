using System;
using System.Linq;
using System.Text.RegularExpressions;

// 这个题目。。。暂时我只会用索引的方法解决，我再思考一下有没有其他方法
// 看了一眼其他人的方法。。。emmmm，直接用的正则表达式，这个思路我还真没有想到
public static class RunLengthEncoding
{
    public static string Encode1(string input)
    {
        string ret = "";
        int i = 0, j = 0;
        while (i < input.Length && j < input.Length)
        {
            if (input[i] != input[j])
            {
                var count = j - i;
                if (count > 1)
                {
                    ret += count.ToString();
                }
                ret += input[i];
                i = j;
                j++;
            }
            else
            {
                j++;
            }

            if (j >= input.Length)
            {
                var count = j - i;
                if (count > 1)
                {
                    ret += count.ToString();
                }
                ret += input[i];
            }
        }

        return ret;
    }

    public static string Decode1(string input)
    {
        string ret = "";
        int i = 0;
        int j = 0;
        while (i < input.Length && j < input.Length)
        {
            if (char.IsNumber(input[j]))
            {
                j++;
            }
            else
            {
                if (i == j)
                {
                    ret += input[i];

                }
                else
                {
                    var numStr = input.Substring(i, j - i);
                    ret += string.Join("", Enumerable.Repeat(input[j], int.Parse(numStr)));
                }
                j++;
                i = j;
            }
        }

        return ret;
    }



    public static string Encode(string input)
    {
        return Regex.Replace(input, @"(\D)(\1+)", m => $"{m.Groups[0].Length}{m.Groups[1].Value}");
    }

    public static string Decode(string input)
    {
        return Regex.Replace(input, @"(\d+)(\D)", m => new(m.Groups[2].Value[0], int.Parse(m.Groups[1].Value)));
    }
}
