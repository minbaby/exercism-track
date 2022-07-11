using System;
using System.Collections.Generic;
using System.Linq;

public static class ResistorColor
{
    private static Dictionary<string, int> colorDict = new Dictionary<string, int> {
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6},
        {"violet", 7},
        {"grey", 8},
        {"white", 9}
    };
    public static int ColorCode1(string color)
    {
        return colorDict[color];
    }

    public static string[] Colors2()
    {
        return colorDict.Keys.ToArray();
    }

    public static int ColorCode(string color)
    {
        return Array.IndexOf(Colors(), color);
    }

    public static string[] Colors()
    {
        return new string[] {
            "black",
            "brown",
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "violet",
            "grey",
            "white"
        };
    }
}