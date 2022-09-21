using System;
using System.Collections.Generic;
using System.Linq;

using Sprache;

// @see https://www.forth.com/starting-forth/2-stack-manipulation-operators-arithmetic/
// @see https://exercism.org/tracks/csharp/exercises/forth/solutions/jeydo6
// Over
// 1 2 swap ==> 2 1
// 1 dup ==> 1 1
// 1 2 3  drop ==> 1 2
// 1 2 3 OVER ==> 1 2 3 2
// 解析成一个list？或者借鉴 cal 直接计算出来一个结果？
// 看起来解析成一个list是最简单的方法（不使用split 进行分割）
public static class Forth
{
    public static string Evaluate(string[] instructions)
    {
        return "";
    }


    private static readonly Parser<Constant> Constant =
        from number in Parse.Number
        from ws in Parse.WhiteSpace.Optional()
        select new Constant(int.Parse(number));

    private static readonly Parser<string> TermIdentifier =
        from term in Parse.Regex(@"[^\s;]+")
        from ws in Parse.WhiteSpace.Optional()
        select term.ToLowerInvariant();

    private static readonly Parser<ForthDefinition> Term =
        TermIdentifier.Select<string, ForthDefinition>(term => term switch
        {
            "+" => new Plus(),
            "-" => new Minus(),
            _ => throw new InvalidOperationException()
        });

    private static readonly Parser<ForthDefinition> CustomTerm = 
        from a in Parse.Char(':')
        from b in Parse.WhiteSpace
        from customTerm in TermIdentifier
        from definitions in Constant.XOr(Term).AtLeastOnce()
        from d in Parse.Char(';')
        from e in Parse.WhiteSpace.Optional()
        select new CustomTerm(customTerm, definitions);
}

internal class ForthState
{
    public Stack<int> Stack { get; } = new();

    public Dictionary<string, IEnumerable<ForthDefinition>> Mapping { get; } = new();

    public override string ToString() => string.Join(" ", Stack.Reverse());
}

internal abstract class ForthDefinition
{
    public abstract void Evaluate(ForthState state);
}

internal class Constant : ForthDefinition
{
    private readonly int _n;

    public Constant(int n) => _n = n;

    public override void Evaluate(ForthState state) => state.Stack.Push(_n);
}


internal abstract class TermDefinition : ForthDefinition
{
    public string Term { get; }
    protected TermDefinition(string term) => Term = term;

    public override void Evaluate(ForthState state)
    {
        if (IsUserTerm(state))
            EvaluateUserTerm(state);
        else
            EvaluateDefaultTerm(state);
    }

    private bool IsUserTerm(ForthState state) => state.Mapping.ContainsKey(Term);

    protected virtual void EvaluateUserTerm(ForthState state)
    {
        foreach (var definition in state.Mapping[Term])
        {
            definition.Evaluate(state);
        }
    }

    public abstract void EvaluateDefaultTerm(ForthState state);
}


internal abstract class BinaryOperation : TermDefinition
{
    protected BinaryOperation(string term) : base(term) { }

    public override void EvaluateDefaultTerm(ForthState state)
    {
        if (state.Stack.Count <= 1) throw new InvalidOperationException();

        var operand2 = state.Stack.Pop();
        var operand1 = state.Stack.Pop();

        foreach (var value in Operation(operand1, operand2))
        {
            state.Stack.Push(value);
        }
    }

    protected abstract List<int> Operation(int x, int y);
}

internal class Plus : BinaryOperation
{
    public Plus() : base("+") { }
    protected override List<int> Operation(int x, int y)
    {
        return new List<int> { x + y };
    }
}

internal class Minus : BinaryOperation
{
    public Minus() : base("-") { }
    protected override List<int> Operation(int x, int y)
    {
        return new List<int> { x - y };
    }
}

internal class Word : TermDefinition
{
    public Word(string str): base(str) {}

    public override void EvaluateDefaultTerm(ForthState state)
    {
        if (!state.Mapping.ContainsKey(Term)) throw new InvalidOperationException();
    }
}

internal class CustomTerm : ForthDefinition
{
    private readonly string _term;

    private readonly ForthDefinition[] _actions;

    public CustomTerm(string term, IEnumerable<ForthDefinition> actions)
    {
        _term = term;
        _actions = actions.ToArray();
    }

    public override void Evaluate(ForthState state)
    {
        if (int.TryParse(_term, out _)) throw new InvalidOperationException();

        var normalizedActions = new List<ForthDefinition>();

        foreach (var action in _actions)
        {
            if (action is Word word)
            {
                normalizedActions.AddRange(state.Mapping[word.Term]);
            }
            else
            {
                normalizedActions.Add(action);
            }
        }

        state.Mapping[_term] = normalizedActions;
    }
}