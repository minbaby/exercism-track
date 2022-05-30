using System;
using System.Linq;
using System.Collections.Generic;

// https://zh.wikipedia.org/wiki/%E8%A5%BF%E6%B4%8B%E9%AA%A8%E7%89%8C
public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        bool ret = true;
        (int, int)? last = null;
        foreach (var x in dominoes)
        {
            if (last == null)
            {
                last = x;
                continue;
            }

            var currentArr = new int[] { x.Item1, x.Item2 };
            var lastArr = new int[] { last!.Value.Item1, last!.Value.Item2 };

            foreach(var y in lastArr) {
                if (currentArr.Contains(y)) {
                    ret = false;
                    break;
                }
            }

            if (!ret) {
                break;
            }
             
        }


        return ret;
    }
}