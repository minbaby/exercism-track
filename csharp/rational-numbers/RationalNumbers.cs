using System;
using System.Diagnostics;
using System.Security.Cryptography;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public struct RationalNumber
{
    // 分子
    private readonly int _numerator;

    // 分母
    private readonly int _denominator;

    public RationalNumber(int numerator, int denominator)
    {
        var gcd = GCD(numerator, denominator);
        _numerator = numerator / gcd;
        _denominator = denominator / gcd;
        
        if (_denominator < 0)
        {
            _numerator = -_numerator;
            _denominator = -_denominator;
        }
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
        new(r1._numerator * r2._denominator + r2._numerator * r1._denominator, r1._denominator * r2._denominator);

    public static RationalNumber operator -(RationalNumber r1) => new RationalNumber(-r1._numerator, r1._denominator);

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => r1 + (-r2);

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        => new(r1._numerator * r2._numerator, r1._denominator * r2._denominator);

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        => new(r1._numerator * r2._denominator, r1._denominator * r2._numerator);

    public RationalNumber Abs() => new(Math.Abs(_numerator), Math.Abs(_denominator));

    public RationalNumber Reduce() => this;

    public RationalNumber Exprational(int power) =>
        new((int)Math.Pow(_numerator, power), (int)Math.Pow(_denominator, power));

    // x^(2/3) = 3√￣ (x^2)
    public double Expreal(int baseNumber) => Math.Pow(baseNumber, _numerator * 1.0 / _denominator);

    // https://oi-wiki.org/math/number-theory/gcd/#_2
    private static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

    public override string ToString() => $"{_numerator}/{_denominator}";
}