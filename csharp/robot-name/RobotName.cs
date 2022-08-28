using System;
using System.Collections.Generic;
public class Robot
{
    private static HashSet<string> nameList = new HashSet<string>();

    private string _Name;

    private const int MAX_LOOP = 100;

    public string Name
    {
        get
        {
            if (!string.IsNullOrEmpty(_Name))
            {
                return _Name;
            }


            return _Name = GenerateUniqueName();
        }
    }

    private string GenerateUniqueName()
    {
        for (int i = 0; i < MAX_LOOP; i++)
        {
            var tmpName = RandomName();
            if (nameList.Add(tmpName))
                return tmpName;
        }

        return "";
    }

    private string RandomName()
    {
        var rnd = new Random();
        string RStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string str = "";
        for (int i = 0; i < 2; i++)
        {
            str += RStr[(new Random()).Next(0, RStr.Length)];
        }

        string str2 = rnd.Next(0, 999).ToString().PadLeft(3, '0');

        return string.Format("{0}{1}", str, str2);

    }

    public void Reset()
    {
        _Name = null;
    }
}