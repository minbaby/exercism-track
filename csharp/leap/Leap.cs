using System;

// https://zh.wikipedia.org/zh-cn/%E9%97%B0%E5%B9%B4
public static class Leap
{
    // on every year that is evenly divisible by 4
    //  except every year that is evenly divisible by 100
    //   unless the year is also evenly divisible by 400
    public static bool IsLeapYear(int year) => year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);


    // 试一下 swithc when 语法
    public static bool IsLeapYear1(int year)
    {
        switch (year)
        {
            case int y when y % 4 == 0 && y % 100 != 0:
                return true;
            case int y when y % 100 == 0 && y % 400 != 0:
                return false;
            case int y when y % 400 == 0:
                return true;
        }

        return false;
    }
}