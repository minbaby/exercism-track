using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int row = matrix.GetLength(0);
        if (row == 0)
        {
            return Array.Empty<(int, int)>();
        }

        int colum = matrix.Length / row;

        IList<(int, int)> rowMax = new List<(int, int)>(row);
        for (int i = 0; i < row; i++)
        {
            int max = int.MinValue;
            for (int j = 0; j < colum; j++)
            {
                if (max <= matrix[i, j])
                {
                    max = matrix[i, j];
                }
            }

            for (int j = 0; j < colum; j++)
            {
                if (max == matrix[i, j])
                {
                    rowMax.Add((i, j));

                }
            }

        }

        IList<(int, int)> columMin = new List<(int, int)>(colum);
        for (int j = 0; j < colum; j++)
        {
            int min = int.MaxValue;
            for (int i = 0; i < row; i++)
            {
                if (min >= matrix[i, j])
                {
                    min = matrix[i, j];
                }
            }

            for (int i = 0; i < row; i++)
            {
                if (min == matrix[i, j])
                {
                    columMin.Add((i, j));
                }
            }
        }

        var ret = columMin.Intersect(rowMax);
        if (ret.Count() == 0)
        {
            return Array.Empty<(int, int)>();
        }

        return ret.Select(p => (p.Item1 + 1, p.Item2 + 1));
    }
}
