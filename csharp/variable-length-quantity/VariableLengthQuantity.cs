using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
//
// 先把 137 转换成二进制：10001001
// 7 bit 一组，把二进制分开，不足的补 0 ，变成 0000001 0001001
// 把最低的7位拿出来，在最高位补0表示最后一位，变成 0000 1001，这个作为最低位，放在最后边。
// 在其他组的最高位补 1 ，表示没有结束，后面跟着还有数据。在这里就是 1000 0001
// 拼在一起，就变成了 1000 0001 0000 1001 .
// 
public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var ret = Array.Empty<uint>();
        foreach (var item in numbers)
        {

            var bits = Convert.ToString(item, 2);

            int num = ((int)Math.Ceiling(bits.Length / 7.0m));

            bits = bits.PadLeft(num * 7, '0');

            var query = bits.Select(f => f == '0' ? 0u : 1u).Chunk(7);
            var total = query.Count();

            var data = query.Select((f, index) =>
            {
                var ret = new uint[8];
                if (index == total - 1)
                {
                    ret[0] = 0;
                }
                else
                {
                    ret[0] = 1;
                }

                for (int i = 1; i < 8; i++)
                {
                    ret[i] = f[i - 1];
                }

                return BitArrayToUint(ret);
            }).ToArray();

            ret = ret.Concat(data).ToArray();
        }

        return ret;
    }

    public static uint[] Decode(uint[] bytes)
    {
        var doneFlag = false;
        var ret = new List<uint>(bytes.Length);
        var total = "";
        foreach (var item in bytes)
        {
            var bits = Convert.ToString(item, 2);
            int num = ((int)Math.Ceiling(bits.Length / 8.0m));

            bits = bits.PadLeft(num * 8, '0');

            var hasNext = bits[0] == '1';
            total += bits.Substring(1);

            if (!hasNext)
            {
                var x = total.Select(f => f == '0' ? 0u : 1u).ToArray();
                ret.Add(BitArrayToUint(x));
                total = "";
                doneFlag = true;
            }
            else
            {
                doneFlag = false;
            }
        }

        if (doneFlag == false)
            throw new InvalidOperationException();


        return ret.ToArray();
    }

    public static uint BitArrayToUint(uint[] data)
    {
        uint result = 0;

        for (int i = 0; i < data.Length; i++)
        {
            result += data[data.Length - i - 1] * (uint)Math.Pow(2, i);
        }
        return result;
    }
}