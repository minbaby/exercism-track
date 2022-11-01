using System;
using System.Collections.Generic;
using System.Linq;

public static class FoodChain
{
    private static readonly (string, string)[] Wow =
    {
        ("fly", ""),
        ("spider", "It wriggled and jiggled and tickled inside her."),
        ("bird", "How absurd to swallow a bird!"),
        ("cat", "Imagine that, to swallow a cat!"),
        ("dog", "What a hog, to swallow a dog!"),
        ("goat", "Just opened her throat and swallowed a goat!"),
        ("cow", "I don't know how she swallowed a cow!"),
        ("horse", "She's dead, of course!"),
    };

    public static string Recite(int verseNumber)
    {
        if (verseNumber is < 1 or > 8)
            throw new ArgumentException();

        var ret = new List<string>
        {
            $"I know an old lady who swallowed a {Wow[verseNumber - 1].Item1}."
        };

        if (verseNumber == 8)
        {
            ret.Add("She's dead, of course!");
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(Wow[verseNumber - 1].Item2))
                ret.Add(Wow[verseNumber - 1].Item2);

            for (int i = verseNumber - 1; i >= 1; i--)
            {
                var val = Wow[i].Item1 == "bird"
                    ? "spider that wriggled and jiggled and tickled inside her"
                    : Wow[i - 1].Item1;
                ret.Add($"She swallowed the {Wow[i].Item1} to catch the {val}.");
            }

            ret.Add($"I don't know why she swallowed the {Wow[0].Item1}. Perhaps she'll die.");
        }

        return string.Join("\n", ret.ToArray());
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var e = Enumerable.Range(startVerse, endVerse)
            .Select(f => Recite(f));

        return string.Join("\n\n", e);
    }
}