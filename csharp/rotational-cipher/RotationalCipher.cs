using System;
using System.Linq;

public static class RotationalCipher
{
    // 这个功能是ok的，但是可以再进行优化
    public static string Rotate1(string text, int shiftKey)
    {
        var charList = text.ToCharArray();
        for (int i = 0; i < charList.Length; i++)
        {
            if (!Char.IsLetter(charList[i]))
            {
                continue;
            }
            var num = (int)charList[i] + shiftKey;

            // 65 - 90 A-Z
            // 97 - 122 a-z
            if (charList[i] >= 97 && charList[i] <= 122 && num > 122)
            {
                num -= 26;
            }

            if (charList[i] >= 65 && charList[i] <= 90 && num > 90)
            {
                num -= 26;
            }

            charList[i] = (char)num;
        }

        return new string(charList);
    }

    // 这个是中第一个方法的优化
    public static string Rotate2(string text, int shiftKey)
    {
        return new string(
            text.ToCharArray().Select(
                f =>
                {
                    if (!Char.IsLetter(f))
                    {
                        return f;
                    }
                    var num = (int)f + shiftKey;
                    if (Char.IsUpper(f) && num > (int)'Z')
                    {
                        num -= 26;
                    }

                    if (Char.IsLower(f) && num > (int)'z')
                    {
                        num -= 26;
                    }
                    return (char)num;
                }
            ).ToArray()
        );
    }

    public static string Rotate(string text, int shiftKey)
    {
        return new string(
            text.ToCharArray().Select(
                f =>
                {
                    var min = Char.IsUpper(f) ? 'A' : 'a';
                    return Char.IsLetter(f) ? (char)((f - min + shiftKey) % 26 + min) : f;
                }
            ).ToArray()
        );
    }
}