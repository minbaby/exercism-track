using System;

public class Clock : IEquatable<Clock>
{
    private TimeOnly timeOnly;

    public Clock(int hours, int minutes)
    {
        hours = hours + minutes / 60;
        minutes = minutes % 60;

        if (minutes < 0)
        {
            minutes = 60 + minutes;
            hours--;
        }

        if (hours >= 24)
            hours = hours % 24;

        if (hours < 0)
            hours = 24 + hours % 24;

        timeOnly = new TimeOnly(hours, minutes);
    }

    public Clock(TimeOnly timeOnly)
    {
        this.timeOnly = timeOnly;
    }

    public Clock Add(int minutesToAdd)
    {
        return new(timeOnly.AddMinutes(minutesToAdd));
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new(timeOnly.AddMinutes(-minutesToSubtract));
    }

    public override string ToString()
    {
        return timeOnly.ToString("HH:mm");
    }

    public bool Equals(Clock obj)
    {
        return timeOnly.Equals(obj.timeOnly);
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return timeOnly.GetHashCode();
    }
}
