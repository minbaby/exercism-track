using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this extension method.");
    }
}

public struct RationalNumber
{
    // 分子
    private int _numerator;
    // 分母
    private int _denominator;

    public RationalNumber(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var _num = r1._numerator * r2._denominator + r2._numerator * r1._denominator;
        var _den = _num == 0 ? 1 : r1._denominator * r2._denominator;

        return new RationalNumber(_num, _den);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        var _num = r1._numerator * r2._denominator - r2._numerator * r1._denominator;
        var _den = _num == 0 ? 1 : r1._denominator * r2._denominator;

        return new RationalNumber(_num, _den);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        var _num = r1._numerator * r2._numerator;
        var _den = r1._denominator * r2._denominator;
        var gcd = GCD(Math.Abs(_num), Math.Abs(_den));
        return new RationalNumber(_num / gcd, _den / gcd);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        if (r2._denominator == 0 || r2._numerator == 0)
        {
            return new RationalNumber();
        }

        var _num = r1._numerator * r2._denominator;
        var _den = r1._denominator * r2._numerator;
        var gcd = GCD(Math.Abs(_num), Math.Abs(_den));
        return new RationalNumber(_num / gcd, _den / gcd);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(_numerator), Math.Abs(_denominator));
    }

    public RationalNumber Reduce()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Exprational(int power)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    // https://oi-wiki.org/math/number-theory/gcd/#_2
    public static int GCD(int a, int b)
    {
        if (a < b)
        {
            (a, b) = (b, a);
        }

        if (b == 0)
        {
            return a;
        }

        return GCD(b, a % b);
    }
}
