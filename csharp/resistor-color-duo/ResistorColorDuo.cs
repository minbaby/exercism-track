using System;
using System.Collections.Generic;
using System.Linq;

public static class ResistorColorDuo
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

    public static int Value(string[] colors)
    {
        return colors
            .Take(2)
            .Reverse()
            .Select((f, i) => map[f] * (int)Math.Pow(10, i))
            .Sum();
    }
}
