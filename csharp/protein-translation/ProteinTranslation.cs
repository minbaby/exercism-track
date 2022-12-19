using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static Dictionary<string, string> map =
        new Dictionary<string, string>
        {
            {"AUG", "Methionine"},

            {"UUU", "Phenylalanine"},
            {"UUC", "Phenylalanine"},

            {"UUA", "Leucine"},
            {"UUG", "Leucine"},

            {"UCU", "Serine"},
            {"UCC", "Serine"},
            {"UCA", "Serine"},
            {"UCG", "Serine"},

            {"UAU", "Tyrosine"},
            {"UAC", "Tyrosine"},

            {"UGU", "Cysteine"},
            {"UGC", "Cysteine"},

            {"UGG", "Tryptophan"},

            {"UAA", "STOP"},
            {"UAG", "STOP"},
            {"UGA", "STOP"},
        };

    public static string[] Proteins(string strand)
    {
        var ret = new List<string>();

        var g = strand.Chunk(3).Select(f => new string(f));

        foreach (var item in g)
        {
            if (!map.TryGetValue(item, out var value))
            {
                continue;
            }

            if (value == "STOP")
            {
                break;
            }

            if (value != "STOP")
            {
                ret.Add(map[item]);
            }
        }

        return ret.ToArray();
    }
}