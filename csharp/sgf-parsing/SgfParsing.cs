using System;
using System.Collections.Generic;
using System.Linq;

using Sprache;

/// <summary>
/// <see cref="https://github.com/antlr/grammars-v4/blob/master/sgf/sgf.g4"/>
/// <see cref="https://exercism.org/tracks/csharp/exercises/sgf-parsing/solutions/davidciglesias"/>
/// </summary>
public class SgfTree
{
    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }

    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }
}

public class SgfParser
{
    private static readonly Parser<SgfTree> SgfTree =
        from leading in Parse.Char('(')
        from a in Parse.AnyChar
        from tailing in Parse.Char(')')
        select new SgfTree(new Dictionary<string, string[]>());

    private static readonly Parser<string> UcLetter = Parse.Upper.AtLeastOnce().Text();

    private static readonly Parser<char> Digit = Parse.Digit;

    private static readonly Parser<char> None = Parse.WhiteSpace;

    private static readonly Parser<string> Number =
        from q in Parse.Chars(new[] { '+', '-' })
        from d in Digit.AtLeastOnce().Text().End()
        select q.ToString() + d;

    private static readonly Parser<string> Real =
        from n in Number
        from d in Digit.Many().Text().End()
        select n + d;

    private static readonly Parser<char> Double = Parse.Chars(new[] { '1', '2' });

    private static readonly Parser<char> Color = Parse.Chars(new[] { 'B', 'W' });

    private static readonly Parser<string> SimpleText = Parse.AnyChar.AtLeastOnce().Text();

    private static readonly Parser<string> Text = Parse.AnyChar.AtLeastOnce().Text();

    private static readonly Parser<string> Point = Parse.AnyChar.AtLeastOnce().Text();

    private static readonly Parser<string> Move = Parse.AnyChar.AtLeastOnce().Text();

    private static readonly Parser<string> Stone = Parse.AnyChar.AtLeastOnce().Text();

    private static readonly Parser<string> ValueType =
        Parse.Upper.Or(Parse.Digit).Many().Text();

    private static readonly Parser<string> Compose =
        from v in ValueType
        from m in Parse.Char(':')
        from vv in ValueType
        select v + m + vv;

    private static readonly Parser<string> CValueType =
        ValueType.Or(Compose);

    private static readonly Parser<string> PropValue =
        from s in Parse.Char('[')
        from cv in CValueType
        from e in Parse.Char(']')
        select s + cv + e;

    private static readonly Parser<IEnumerable<string>> PropIdent = UcLetter.AtLeastOnce().Many();

    private static readonly Parser<IEnumerable<string>> Property =
        from pi in PropIdent
        from pv in PropValue.AtLeastOnce()
        select pi.Concat(pv);

    private static readonly Parser<string> Node =
        from n in Parse.Char(';')
        from pp in Property.AtLeastOnce()
        select n.ToString();


    public static SgfTree ParseTree(string input) => SgfTree.Parse(input);
}