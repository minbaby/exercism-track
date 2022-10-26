using System;
using System.Collections;
using System.Linq;

public enum Schedule
{
    Teenth, // 10 (13-19)
    First, // 1
    Second,  //2
    Third, // 3
    Fourth, // 5
    Last
}

// 思路 1.  1-end of year。 筛出所有符合 dayofWeek 的 数据，然后根据 schedule 筛出最终数据。
public class Meetup
{
    private int month;
    private int year;
    public Meetup(int month, int year)
    {
        this.month = month;
        this.year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var dayOfWeekList = Enumerable.Range(1, DateTime.DaysInMonth(year, month))
            .Select(day => new DateTime(year, month, day))
            .Where(dt => dt.DayOfWeek == dayOfWeek).ToList();

        return schedule switch
        {
            Schedule.First => dayOfWeekList[0],
            Schedule.Second => dayOfWeekList[1],
            Schedule.Third => dayOfWeekList[2],
            Schedule.Fourth => dayOfWeekList[3],
            Schedule.Teenth => dayOfWeekList.Where(dt => dt.Day >= 13).ToList()[0],
            Schedule.Last => dayOfWeekList[dayOfWeekList.Count - 1],
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}