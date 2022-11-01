using System;
using System.Collections.Generic;
using System.Linq;

public static class House
{
    // malt
    // rat                                  ate 
    // cat                                  killed
    // dog                                  worried
    // cow with the crumpled horn           tossed
    // maiden all forlorn                   milked
    // man all tattered and torn            kissed
    // priest all shaven and shorn          married
    // rooster that crowed in the morn      woke
    // farmer sowing his corn               kept
    // horse and the hound and the horn     belonged to

    public static (string, string)[] wow =
    {
        ("house", "Jack built"),
        ("malt", "lay in"),
        ("rat", "ate"),
        ("cat", "killed"),
        ("dog", "worried"),
        ("cow with the crumpled horn", "tossed"),
        ("maiden all forlorn", "milked"),
        ("man all tattered and torn", "kissed"),
        ("priest all shaven and shorn", "married"),
        ("rooster that crowed in the morn", "woke"),
        ("farmer sowing his corn", "kept"),
        ("horse and the hound and the horn", "belonged to"),
    };

    public static string Recite(int verseNumber)
    {
        return Enumerable.Range(0, verseNumber).Reverse()
            .Select(f => $" the {wow[f].Item1} that {wow[f].Item2}")
            .Append(".")
            .Aggregate("This is", (acc, part) => acc + part);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var ret = Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(f => Recite(f));
        return string.Join("\n", ret);
    }
}