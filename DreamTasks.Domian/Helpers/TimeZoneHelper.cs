namespace Domain.Helpers;

public static class TimeZoneHelper
{

    public const string _defaultTimeZoneId = "Egypt Standard Time";

    /// <summary>
    /// Gets a TimeZoneInfo by its ID, with safe fallback to UTC if not found.
    /// </summary>
    public static TimeZoneInfo GetTimeZone(string timeZoneId)
    {
        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }
        catch (TimeZoneNotFoundException)
        {
            return TimeZoneInfo.Utc;
        }
        catch (InvalidTimeZoneException)
        {
            return TimeZoneInfo.Utc;
        }
    }

    /// <summary>
    /// Converts a UTC DateTime to the specified time zone.
    /// </summary>
    public static DateTime ConvertFromUtc(DateTime utcDateTime, string timeZoneId)
    {
        var timeZone = GetTimeZone(timeZoneId);
        return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
    }

    /// <summary>
    /// Gets the current local time for the specified time zone.
    /// </summary>
    public static DateTime GetCurrentDateTime(string? timeZoneId = _defaultTimeZoneId)
    {
        if (string.IsNullOrWhiteSpace(timeZoneId))
            timeZoneId = _defaultTimeZoneId;

        return ConvertFromUtc(DateTime.UtcNow, timeZoneId);
    }

}
