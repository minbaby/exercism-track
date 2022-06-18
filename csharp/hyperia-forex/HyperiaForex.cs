using System;
using System.Runtime;
public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // override object.Equals
    public override bool Equals(object obj)
    {
        //
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //

        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        // TODO: write your implementation of Equals() here

        return this == (CurrencyAmount)obj;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        return amount.GetHashCode() + currency.GetHashCode();
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
    {
        return !(a == b);
    }

    // TODO: implement comparison operators
    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return a.amount > b.amount;
    }
    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return a.amount < b.amount;
    }

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return new CurrencyAmount(a.amount * b.amount, a.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return new CurrencyAmount(a.amount / b.amount, a.currency);
    }

    // TODO: implement type conversion operators
    public static implicit operator decimal(CurrencyAmount a)
    {
        return a.amount;
    }

    public static implicit operator double(CurrencyAmount a)
    {
        return (double)a.amount;
    }
}
