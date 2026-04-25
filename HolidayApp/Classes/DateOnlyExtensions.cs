using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;

namespace HolidayApp.Classes;
/// <summary>
/// Provides extension methods for the <see cref="DateOnly"/> structure to handle holidays, working days,
/// and other date-related operations.
/// </summary>
/// <remarks>
/// This class includes methods to determine whether a date is a holiday or a working day, 
/// to add a specified number of working days to a date, and to retrieve holidays for an entire year.
/// It leverages culture-specific rules for holidays and working days through the <see cref="WorkingDayCultureInfo"/> class.
/// </remarks>
public static class DateOnlyExtensions
{
    /// <summary>
    /// Determines whether the specified date is a holiday.
    /// </summary>
    /// <param name="day">The date to check.</param>
    /// <returns>
    /// <c>true</c> if the specified date is a holiday; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="WorkingDayCultureInfo"/> class to determine holidays.
    /// It considers culture-specific holiday rules to identify whether the given date is a holiday.
    /// </remarks>
    public static bool IsHoliday(this DateOnly day)
    {
        var date = DateTimeFromDateOnly(day);
        var workingDayCultureInfo = new WorkingDayCultureInfo();
        return workingDayCultureInfo.IsHoliday(date);
    }

    /// <summary>
    /// Determines whether the specified date is a working day.
    /// </summary>
    /// <param name="day">The date to check.</param>
    /// <returns>
    /// <c>true</c> if the specified date is a working day; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="WorkingDayCultureInfo"/> class to determine working days.
    /// It considers weekends and holidays as defined by the culture-specific working day rules.
    /// </remarks>
    public static bool IsWorkingDay(this DateOnly day)
    {
        var date = DateTimeFromDateOnly(day);
        var workingDayCultureInfo = new WorkingDayCultureInfo();
        return workingDayCultureInfo.IsWorkingDay(date);
    }

    /// <summary>
    /// Adds the specified number of working days to the given date.
    /// </summary>
    /// <param name="day">The starting date to which working days will be added.</param>
    /// <param name="workingDays">The number of working days to add. Can be positive or negative.</param>
    /// <returns>
    /// A <see cref="DateOnly"/> representing the date after adding the specified number of working days.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="WorkingDayCultureInfo"/> class to determine working days.
    /// It skips holidays and weekends as defined by the culture-specific working day rules.
    /// </remarks>
    public static DateOnly AddWorkingDays(DateOnly day, int workingDays)
    {
        var date = DateTimeFromDateOnly(day);
        var newDate = date.AddWorkingDays(workingDays, new WorkingDayCultureInfo());
        return DateOnly.FromDateTime(newDate);
    }

    /// <summary>
    /// Adds a full business week (7 working days) to the specified date.
    /// </summary>
    /// <param name="day">The starting date to which a business week will be added.</param>
    /// <returns>
    /// A <see cref="DateOnly"/> representing the date after adding 7 working days.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="WorkingDayCultureInfo"/> class to determine working days.
    /// It skips holidays and weekends as defined by the culture-specific working day rules.
    /// </remarks>
    public static DateOnly AddBusinessWeekDay(this DateOnly day)
    {
        var date = DateTimeFromDateOnly(day);
        var newDate = date.AddWorkingDays(7, new WorkingDayCultureInfo());
        return DateOnly.FromDateTime(newDate);
    }
    /// <summary>
    /// Retrieves all holidays for the entire year based on the specified date.
    /// </summary>
    /// <param name="day">The date for which the year's holidays are to be retrieved.</param>
    /// <returns>
    /// A dictionary where the keys are <see cref="DateOnly"/> objects representing the dates of the holidays, 
    /// and the values are <see cref="Holiday"/> objects containing details about each holiday.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="WorkingDayCultureInfo"/> class to determine holidays.
    /// The returned dictionary includes all holidays for the year of the provided date.
    /// </remarks>
    public static IDictionary<DateOnly, Holiday> AllYearHolidays(this DateOnly day)
    {
        IDictionary<DateTime, Holiday>? x = day
            .ToDateTime(TimeOnly.Parse("00:00 AM"))
            .AllYearHolidays(new WorkingDayCultureInfo());
        return x.ToDictionary(kvp => DateOnly.FromDateTime(kvp.Key), kvp => kvp.Value);
    }

    private static DateTime DateTimeFromDateOnly(DateOnly day) 
        => day.ToDateTime(new TimeOnly(0, 0));
}
