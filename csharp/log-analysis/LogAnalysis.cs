using System;

public static class LogAnalysis
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string separator)
    {
        return str.Split(separator)[1];
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string first, string second)
    {
        int startIndex = str.IndexOf(first);
        int secondInddex = str.IndexOf(second);
        return str.Substring(
            startIndex + first.Length,
            secondInddex - startIndex - first.Length
        );
    }

    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(":").Trim();
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}