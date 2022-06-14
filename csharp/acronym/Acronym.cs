using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate1(string phrase)
    {
        string ret = "";
        var t = phrase.Split(new char[] { '-', ' ' }).ToArray();
        foreach (var str in t)
        {
            foreach (var c in str)
            {
                if (Char.IsLetter(c))
                {
                    ret += Char.ToUpper(c);
                    break;
                }
            }
        }

        return ret;
    }

    public static string Abbreviate(string phrase)
    {
        string ret = "";
        phrase.Split(new char[] { ' ', '-' }).ToList().ForEach(f =>
        {
            var s = f.ToList().First(f => Char.IsLetter(f));
            ret += s;
        });

        return ret.ToUpper();
    }
}