
using System.Globalization;
using System.Security.Principal;

namespace Exercism.Time;

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


public struct SalonLocationTimeZoneIds
{
    public static Dictionary<Location, string> WindowsOS() => new Dictionary<Location, string>
    {
        { Location.NewYork, "Eastern Standard Time" },
        { Location.London, "GMT Standard Time" },
        { Location.Paris, "W. Europe Standard Time" },
    };
    
    public static Dictionary<Location, string> LinuxOS() => new Dictionary<Location, string>
    {
        { Location.NewYork, "America/New_York" },
        { Location.London, "Europe/London" },
        { Location.Paris, "Europe/Paris" },
    };
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var appointmentDate = DateTime.Parse(appointmentDateDescription);
        var tzId = OperatingSystem.IsWindows()
            ? SalonLocationTimeZoneIds.WindowsOS()[location]
            : SalonLocationTimeZoneIds.LinuxOS()[location];
        
        return TimeZoneInfo.ConvertTimeToUtc(appointmentDate, TimeZoneInfo.FindSystemTimeZoneById(tzId));
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        DateTime startDate = dt.AddDays(-7);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(OperatingSystem.IsWindows()
            ? SalonLocationTimeZoneIds.WindowsOS()[location]
            : SalonLocationTimeZoneIds.LinuxOS()[location]);

        var wasDST = timeZone.IsDaylightSavingTime(startDate);
        var isDST = timeZone.IsDaylightSavingTime(dt);
        return wasDST != isDST;
    }
}