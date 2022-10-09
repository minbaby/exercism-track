using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var str = string.Join("", phoneNumber.Where(f => char.IsDigit(f)));

        var match = new Regex(@"^(1?)([2-9]\d{2})([2-9]\d{2})(\d{4})$");

        return match.IsMatch(str) ? match.Replace(str, "$2$3$4") : throw new ArgumentException();
    }
    public static string Clean1(string phoneNumber)
    {
        if (phoneNumber.Length == 11 && phoneNumber[0] == '1')
        {
            return phoneNumber.Remove(0, 1);
        }

        var x = phoneNumber.Trim('+').Split(new char[] { ' ', '.', '-' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        if (x.Count != 3 && x.Count != 4)
        {
            throw new ArgumentException();
        }

        if (x.Count == 4)
        {
            if (x.First() != "1")
            {
                throw new ArgumentException();
            }

            x.RemoveAt(0);
        }

        x[0] = x.First().Trim(new char[] { '(', ')' });
        var fn = int.Parse(x[0][0].ToString());
        if (fn < 2 || fn > 9)
        {
            throw new ArgumentException();
        }

        fn = int.Parse(x[1][0].ToString());
        if (fn < 2 || fn > 9)
        {
            throw new ArgumentException();
        }

        return string.Join("", x);
    }
}