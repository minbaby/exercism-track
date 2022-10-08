using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0) 
            throw new ArgumentOutOfRangeException();

        var times = 0;
        var n = number;
        while (n > 1)
        {
            if (n % 2 != 0)
            {
                n = n * 3 + 1;
            }
            else
            {
                n = n / 2;
            }
            times++;
        }
        return times;
    }
}