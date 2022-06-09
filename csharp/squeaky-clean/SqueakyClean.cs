using System;
using System.Text;
public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();
        var charArr = identifier.ToCharArray();
        for (int i = 0; i < charArr.Length; i++)
        {
            switch (charArr[i])
            {
                case char c when Char.IsWhiteSpace(c):
                    sb.Append('_');
                    break;
                case char c when Char.IsControl(c):
                    sb.Append("CTRL");
                    break;
                case char c when Char.IsDigit(c):
                    break;
                case char c when c >= 'α' && c <= 'ω':
                    break;
                case char c when c == '-':
                    if (i + 1 < charArr.Length)
                        charArr[i + 1] = Char.ToUpper(charArr[i + 1]);
                    break;
                case char c when !Char.IsLetter(c):
                    break;
                default:
                    sb.Append(charArr[i]);
                    break;
            }
        }

        return sb.ToString();
    }
}
