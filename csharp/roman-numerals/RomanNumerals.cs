using System;
using System.Collections.Generic;
using System.Text;

// 罗马规则
// 1.相同的数字连写，所表示的数等于这些数相加。如：XXX=30，CC=200
// 2. 如果大的数字在前，小的数字在后，所表示的数等于这些数相加。如：LX=60
// 3. 如果小的数字在前，大的数字在后，所表示的数等于从大数减去小数。如：IX=9，XC=90，CM=900
// 4. 如果数字上面有一横线，表示这个数字增值1000倍。
//
// 特殊的一些全部列出来，每个“整数”的前一个数字都是特殊数字，每个都进行计算的话就很难
// 4 => IV, 9 => IX,
public static class RomanNumeralExtension
{
    public static int[] keys = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
    public static string[] values = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

    public static string ToRoman(this int value)
    {
        var sb = new StringBuilder();

        var tmp = value;
        for (int i = 0; i < keys.Length; i++)
        {
            var index = keys.Length - i - 1;
            while (value >= keys[index])
            {
                sb.Append(values[index]);
                value = value - keys[index];
            }
        }

        return sb.ToString();
    }
}