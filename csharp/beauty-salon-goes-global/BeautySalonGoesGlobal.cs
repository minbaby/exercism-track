using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{

    public static TimeZoneInfo LocationToTimezoneInfo(Location location)
    {
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var tzStr = location switch
        {
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentException(),
        };

        return TimeZoneInfo.FindSystemTimeZoneById(tzStr);
    }

    public static CultureInfo LocationToCultureInfo(Location location) => location switch
    {
        Location.London => new CultureInfo("en-GB"),
        Location.NewYork => new CultureInfo("en-US"),
        Location.Paris => new CultureInfo("fr-FR"),
        _ => throw new ArgumentException()
    };

    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var localDateTime = DateTime.Parse(appointmentDateDescription);

        return TimeZoneInfo.ConvertTime(localDateTime, LocationToTimezoneInfo(location), TimeZoneInfo.Utc);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => appointment
        };
    }

    // 这是啥玩意，夏令时。。。不懂
    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var tz = LocationToTimezoneInfo(location);
        var startDate = dt.AddDays(-7);
        return tz.IsDaylightSavingTime(startDate) != tz.IsDaylightSavingTime(dt);
    }

    // 时间解析应该会受到 location 的影响
    // 2020/02/02 
    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        return DateTime.TryParse(dtStr, LocationToCultureInfo(location), DateTimeStyles.None, out var dt) 
        ? dt 
        : new DateTime(1, 1, 1);
    }
}