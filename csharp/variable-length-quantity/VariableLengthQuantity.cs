using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
//
// 先把 137 转换成二进制：10001001 （uint 默认就可以当作二进制处理）
// 7 bit 一组，把二进制分开，不足的补 0 ，变成 0000001 0001001，（其实我可以每次循环处理7bit，这样就不用进行分组了）
// 把最低的7位拿出来，在最高位补0表示最后一位，变成 0000 1001，这个作为最低位，放在最后边。
// 在其他组的最高位补 1 ，表示没有结束，后面跟着还有数据。在这里就是 1000 0001
// 拼在一起，就变成了 1000 0001 0000 1001 .
// ~~~ 上边这个方法是核心思路，具体实现有很多，刚开始的时候我就是用的最笨的方法做的
// 
public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var ret = new List<uint>();
        foreach (var b in numbers)
        {
            var index = 0u;

            var tmpList = new List<uint>();

            var _b = b;
            while (true)
            {
                index++;
                var _tmp = _b & 0b_0111_1111;

                _b >>= 7;

                if (index != 1)
                {
                    // 不是最后一个
                    _tmp |= 0b_1000_0000;
                }

                tmpList.Add(_tmp);


                if (_b == 0)
                {
                    break;
                }
            }

            tmpList.Reverse();
            ret.AddRange(tmpList);
        }
        return ret.ToArray();
    }
    public static uint[] Decode(uint[] bytes)
    {
        var ret = new List<uint>();
        var num = 0u;

        var hasDone = false;
        foreach (var b in bytes)
        {
            var _b = b;

            var _tmp = _b & 0b_1111_1111;
            var _value = _tmp & 0b_0111_1111;

            if ((_tmp & 0b_1000_0000) == 0b_1000_0000)
            {
                hasDone = false;
                // 没有结束
                num = (num << 7) | _value;
            }
            else
            {
                hasDone = true;
                // 结束了，我是最后一个
                num = (num << 7) | _value;
                ret.Add(num);
                num = 0u;
            }
        }

        if (!hasDone)
        {
            throw new InvalidOperationException();
        }

        return ret.ToArray();
    }
    public static uint[] Encode1(uint[] numbers)
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
    public static uint[] Decode1(uint[] bytes)
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