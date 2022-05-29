using System;
using System.Linq;

public static class Bob
{
    public static bool IsQuiet(string statement)
        => string.IsNullOrWhiteSpace(statement);

    private static bool IsYelled(string statement)
        => statement.Any(Char.IsUpper) && statement.ToUpper() == statement;

    private static bool IsYelledQuesition(string statement)
        => IsYelled(statement) &&  IsQuesition(statement);

    private static bool IsQuesition(string statement)
        => statement.Trim().EndsWith("?");

    public static string Response(string statement)
    {

        switch (statement)
        {
            case string msg when IsYelledQuesition(statement):
                return "Calm down, I know what I'm doing!";
            case string msg when IsQuesition(statement):
                return "Sure.";
            case string msg when IsYelled(statement):
                return "Whoa, chill out!";
            case string msg when IsQuiet(statement):
                return "Fine. Be that way!";
            default:
                return "Whatever.";
        }
    }

}