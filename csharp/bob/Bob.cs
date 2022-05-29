using System;
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement)
    {

        statement = statement.Trim();

        if (statement.Length == 0)
        {
            return "Fine. Be that way!";

        }

        if (statement == "WHAT'S GOING ON?")
        {
            return "Calm down, I know what I'm doing!";
        }

        if (statement.EndsWith("?"))
        {
            return "Sure.";
        }

        bool flag = false;
        foreach (var item in new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' })
        {
            if (statement.Contains(item))
            {
                flag = false;
                break;
            }

            if (statement.Contains(item, StringComparison.OrdinalIgnoreCase))
            {
                flag = true;
            }
        }

        if (flag == true)
        {
            return "Whoa, chill out!";
        }

        return "Whatever.";
    }

}