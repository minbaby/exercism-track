using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var ret = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };


        return sequence.Aggregate(ret, (dict, letter) =>
        {
            if (!dict.ContainsKey(letter)) throw new ArgumentException();
            dict[letter]++;
            return dict;
        });
    }
}