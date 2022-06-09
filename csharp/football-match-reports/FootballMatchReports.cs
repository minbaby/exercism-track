using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 => "center back",
            4 => "center back",
            5 => "right back",
            6 => "midfielder",
            7 => "midfielder",
            8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public static string AnalyzeOffField(object report)
    {
        string ret = string.Empty;
        switch (report)
        {
            case string a:
                ret = a;
                break;
            case int a:
                ret = $"There are {a} supporters at the match.";
                break;
            case Foul a:
                ret = a.GetDescription();
                break;
            case Injury a:
                ret = $"Oh no! {a.GetDescription()} Medics are on the field.";
                break;
            case Manager a:
                ret = a.Name + (a.Club != null ? $" ({a.Club})" : "");

                break;
            case Incident a:
                ret = a.GetDescription();
                break;
            default:
                throw new ArgumentException();
        }

        return ret;
    }
}
