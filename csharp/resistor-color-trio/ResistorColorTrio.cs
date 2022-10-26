using System;
using System.Collections.Generic;

public static class ResistorColorTrio
{
    public static Dictionary<string, int> map = new Dictionary<string, int>()
    {
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6},
        {"violet", 7},
        {"grey", 8},
        {"white", 9},
    };
    public static string Label(string[] colors)
    {
        int f = map[colors[0]] * 10 + map[colors[1]];
        int oooo = colors.Length == 3 ? map[colors[2]] : 0;

        f = f * (int)Math.Pow(10, oooo);
        if (f > 1000)
        {
            return $"{f / 1000} kiloohms";
        }
        else
        {
            return $"{f} ohms";
        }
    }
}