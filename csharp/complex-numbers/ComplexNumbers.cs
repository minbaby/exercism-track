using System;

public struct ComplexNumber
{
    private double real;
    private double imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    public double Real()
    {
        return real;
    }

    public double Imaginary()
    {
        return imaginary;
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        return new ComplexNumber(
            (real * other.Real() - imaginary * other.Imaginary()),
            real * other.Imaginary() + imaginary * other.Real()
        );
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(
            real + other.Real(),
            imaginary + other.Imaginary()
        );
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        return new ComplexNumber(
            real - other.Real(),
            imaginary - other.Imaginary()
        );
    }

    public ComplexNumber Div(ComplexNumber other)
    {
            return new ComplexNumber(
                (real * other.real + imaginary * other.imaginary) / (other.real * other.real + other.imaginary * other.imaginary),
                (imaginary * other.real - real * other.imaginary) / (other.real * other.real + other.imaginary * other.imaginary)
            );
    }

    public double Abs()
    {
        return Math.Sqrt(real * real + imaginary * imaginary);
    }

    public ComplexNumber Conjugate()
    {
        return new ComplexNumber(real, -imaginary);
    }

    public ComplexNumber Exp()
    {
        return new ComplexNumber(
            Math.Pow(Math.E, real) * Math.Cos(imaginary),
            Math.Pow(Math.E, real) * Math.Sin(imaginary)
        );
    }
}