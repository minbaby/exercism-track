using System;
using System.Linq;
using System.Collections.Generic;

// https://zh.wikipedia.org/wiki/%E8%A5%BF%E6%B4%8B%E9%AA%A8%E7%89%8C
// 示例 [2, 1] [2, 3] [3, 1]
// 可能的排序方法
// 1. [1, 2] [2, 3] [3, 1]
// 2. [2, 1] [1, 3] [3, 2]
// 3. [2, 3] [3, 1] [1, 2]
// 4. [3, 2] [2, 1] [1, 3]
// 5. [1, 3] [3, 2] [2, 1]
// 6. [3, 1] [1, 2] [2, 3]
// 这个题，大概思路能整理出来，但是不知道如何转换成代码，
// 以下的代码参考自：https://exercism.org/tracks/csharp/exercises/dominoes/solutions/david82
// 有点像是链表操作， (0, 0) 是一个辅助用的头
public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        return TryChain(dominoes.ToList(), (0, 0));
    }

    // 因为多米诺骨牌中不存在 0 这个数字，所以我们把他当作特殊数字：即，初始数字
    public static bool TryChain(List<(int, int)> dominoes, (int first, int last) state)
    {
        // 如果列表中没有元素了（最后一个，或者只有一个的情况），且 first == last ，表示这个 YES 的
        if (dominoes.Count() == 0 && state.first == state.last)
        {
            return true;
        }

        for (int i = 0; i < dominoes.Count(); i++)
        {
            // 从第一个元素开始
            var (currentA, currentB) = dominoes[i];
            // 如果初始数字，则 更新 state为 当前元素
            if (state.last == 0)
            {
                state = (currentA, currentB);
            }

            // 如果 last == 当前元素的 a，则
            else if (state.last == currentA)
            {
                state.last = currentB;
            }
            else if (state.last == currentB)
            {
                state.last = currentA;
            }
            else
            {
                continue;
            }

            var dominoesCopy = new List<(int, int)>(dominoes);
            dominoesCopy.RemoveAt(i);
            if (TryChain(dominoesCopy, state))
            {
                return true;
            }
        }

        return false;
    }
}