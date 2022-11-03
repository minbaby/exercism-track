using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) =>
        (from d in old
            from dd in d.Value
            select (k: dd.ToLower(), v: d.Key))
        .ToDictionary(f => f.k, f => f.v);

    public static Dictionary<string, int> Transform1(Dictionary<int, string[]> old) =>
        old.SelectMany(f => f.Value, (v, k) => (k: k, v:v.Key))
            .ToDictionary(f => f.k.ToLower(), f => f.v);
}