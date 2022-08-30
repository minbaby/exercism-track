using System;
using System.Collections.Generic;
using System.Linq;

public static class MatchingBrackets
{

    private static List<char> left = new List<char>() {
        '{',
        '[',
        '(',
    };
    private static List<char> right = new List<char>() {
        '}',
        ']',
        ')',
    };

    private static List<char> all = left.Concat(right).ToList();

    public static bool IsPaired(string input)
    {
        var stack = new Stack<char>();

        foreach (var c in input)
        {
            if (!all.Contains(c))
                continue;

            if (left.Contains(c))
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                    return false;

                var cc = stack.Pop();
                var index = left.IndexOf(cc);
                var needRight = right[index];
                if (needRight != c)
                {
                    return false;
                }
            }
        }


        return stack.Count == 0;
    }
}
