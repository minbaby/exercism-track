using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var ret = new List<int[]>();

        for (int i = 0; i < rows; i++)
        {
            var row = new List<int>();

            if (i == 0)
            {
                row.Add(1);
            }
            else
            {
                var preRow = ret[i - 1];
                var preRowLen = preRow.Length;
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        row.Add(preRow[j] + preRow[j - 1]);
                    }
                }
            }

            ret.Add(row.ToArray());
        }

        return ret.ToArray();
    }

}