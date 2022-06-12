using System;
using System.Linq;

public static class Isogram
{
    // 这个解法，似乎理解错题目了，- -，英文的这些真是。。。
    public static bool IsIsogram2(string word)
    {
        word = word.ToLower();
        if (!word.Contains("-") && !word.Contains(" "))
        {
            return word.ToCharArray().Distinct().Count() == word.ToCharArray().Count();
        }
        else
        {
            foreach (var w in word.Split(new char[] { ' ', '-' }))
            {
                if (w.ToCharArray().Distinct().Count() != w.ToCharArray().Count())
                {
                    return false;
                }
            }

            return true;
        }
    }

    public static bool IsIsogram(string word)
    {
        var wordArr = word.ToLower().Replace(" ", "").Replace("-", "").ToCharArray();
        return wordArr.Distinct().Count() == wordArr.Count();
    }
}
