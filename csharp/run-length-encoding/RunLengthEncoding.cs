using System;
using System.Linq;


// 这个题目。。。暂时我只会用索引的方法解决，我再思考一下有没有其他方法
public static class RunLengthEncoding
{
    public static string Encode(string input)
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

    public static string Decode(string input)
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
}
