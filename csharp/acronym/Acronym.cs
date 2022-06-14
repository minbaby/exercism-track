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

    public static string Abbreviate2(string phrase)
    {
        string ret = "";
        phrase.Split(new char[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(f => ret += f.ToList().First(f => Char.IsLetter(f)););

        return ret.ToUpper();
    }

    public static string Abbreviate(string phrase)
    {
        return String.Join("", phrase.Split(new char[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries).Select(f => f[0])).ToUpper();
    }
}