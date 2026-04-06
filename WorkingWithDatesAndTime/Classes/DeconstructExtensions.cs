namespace WorkingWithDatesAndTime.Classes;
/// <summary>
/// Provides extension methods for deconstructing date and time-related types into their individual components.
/// </summary>
/// <remarks>
/// Discards (an underscore) can be used to ignore specific components when deconstructing.
/// For example, if you only need the year and month from a DateOnly object, you can
/// deconstruct it as follows:
/// var (year, month, _ ) = new DateOnly(2026, 4, 9);
/// </remarks>
internal static class DeconstructExtensions
{

    //public static void Deconstruct(this DateOnly date, out int day, out int month, out int year) 
    //    => (day, month, year) = (date.Day, date.Month, date.Year);

    //public static void Deconstruct(this DateTime date, out int day, out int month, out int year) 
    //    => (day, month, year) = (date.Day, date.Month, date.Year);

    //public static void Deconstruct(this TimeOnly time, out int hour, out int minute, out int second)
    //    => (hour, minute, second) = (time.Hour, time.Minute, time.Second);

    public static void Deconstruct(this TimeSpan timeSpan, out int hours, out int minutes, out int seconds)
        => (hours, minutes, seconds) = (timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

    //public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year)
    //    => (day, month, year) = (date.Day, date.Month, date.Year);

    //public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year, out TimeSpan offset)
    //    => (day, month, year, offset) = (date.Day, date.Month, date.Year, date.Offset);
}
