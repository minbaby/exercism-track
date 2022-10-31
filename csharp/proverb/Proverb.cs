using System;
using System.Collections.Generic;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0)
        {
            return subjects;
        }

        var ret = new List<string>();

        for (int i = 0; i < subjects.Length - 1; i++)
        {
            ret.Add($"For want of a {subjects[i]} the {subjects[i + 1]} was lost.");
        }

        ret.Add($"And all for the want of a {subjects[0]}.");

        return ret.ToArray();
    }
}