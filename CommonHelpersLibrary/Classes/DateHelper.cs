namespace CommonHelpersLibrary.Classes;

/// <summary>
/// Provides utility methods for working with dates, including retrieving weekend dates.
/// </summary>
/// <remarks>
/// This static class contains methods to assist in date-related operations, such as identifying
/// weekends within a specified range or month. It is designed to simplify common date-handling
/// tasks.
/// </remarks>
public static class DateHelper
{
    public static List<DateOnly> GetWeekendDates(DateOnly startDate, DateOnly endDate)
    {
        if (endDate < startDate)
        {
            throw new ArgumentException("endDate must be >= startDate");
        }

        var results = new List<DateOnly>();

        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            {
                results.Add(date);
            }
        }

        return results;
    }

    /// <summary>
    /// Retrieves a list of weekend dates (Saturdays and Sundays) for a specified year and month.
    /// </summary>
    /// <param name="year">The year for which to retrieve weekend dates.</param>
    /// <param name="month">The month for which to retrieve weekend dates.</param>
    /// <returns>A list of <see cref="DateOnly"/> objects representing the weekend dates within the specified year and month.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="month"/> is less than 1 or greater than 12, or if <paramref name="year"/> is outside the valid range for <see cref="DateOnly"/>.
    /// </exception>
    public static List<DateOnly> GetWeekendDates(int year, int month)
    {
        var start = new DateOnly(year, month, 1);
        var end = start.AddMonths(1).AddDays(-1);

        return GetWeekendDates(start, end);
    }

    /// <summary>
    /// Retrieves a list of workdays (Monday through Friday) within a specified date range.
    /// </summary>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>A list of <see cref="DateOnly"/> objects representing the workdays within the specified date range.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="endDate"/> is earlier than <paramref name="startDate"/>.
    /// </exception>
    /// <remarks>
    /// This method identifies all workdays (Monday through Friday) within the specified date range.
    /// </remarks>
    public static List<DateOnly> GetWorkDays(DateOnly startDate, DateOnly endDate)
    {
        if (endDate < startDate)
        {
            throw new ArgumentException("endDate must be >= startDate");
        }

        var results = new List<DateOnly>();

        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek is >= DayOfWeek.Monday and <= DayOfWeek.Friday)
            {
                results.Add(date);
            }
        }

        return results;
    }

    /// <summary>
    /// Retrieves a list of workdays (Monday through Friday) for a specified year and month.
    /// </summary>
    /// <param name="year">The year for which to retrieve workdays.</param>
    /// <param name="month">The month for which to retrieve workdays.</param>
    /// <returns>A list of <see cref="DateOnly"/> objects representing the workdays within the specified year and month.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="month"/> is less than 1 or greater than 12, or if <paramref name="year"/> is outside the valid range for <see cref="DateOnly"/>.
    /// </exception>
    /// <remarks>
    /// This method identifies all workdays (Monday through Friday) within the specified year and month.
    /// </remarks>
    public static List<DateOnly> GetWorkDays(int year, int month)
    {
        var start = new DateOnly(year, month, 1);
        var end = start.AddMonths(1).AddDays(-1);

        return GetWorkDays(start, end);
    }

    /// <summary>
    /// Groups workdays (Monday through Friday) within a specified date range by the starting date of each week.
    /// </summary>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>
    /// A dictionary where the key is the <see cref="DateOnly"/> representing the Monday of each week,
    /// and the value is a list of <see cref="DateOnly"/> objects representing the workdays within that week.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="endDate"/> is earlier than <paramref name="startDate"/>.
    /// </exception>
    /// <remarks>
    /// This method identifies all workdays (Monday through Friday) within the specified date range
    /// and groups them by the week they belong to, with each week starting on a Monday.
    /// </remarks>
    public static Dictionary<DateOnly, List<DateOnly>> GetWorkDaysGroupedByWeek(DateOnly startDate, DateOnly endDate)
    {
        if (endDate < startDate)
        {
            throw new ArgumentException("endDate must be >= startDate");
        }

        var results = new Dictionary<DateOnly, List<DateOnly>>();

        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek is >= DayOfWeek.Monday and <= DayOfWeek.Friday)
            {
                // Determine the Monday of the current week
                var weekStart = date.AddDays(-(int)date.DayOfWeek + (int)DayOfWeek.Monday);

                if (!results.ContainsKey(weekStart))
                {
                    results[weekStart] = [];
                }

                results[weekStart].Add(date);
            }
        }

        return results;
    }

    /// <summary>
    /// Calculates the number of business days (Monday through Friday) between two specified dates.
    /// </summary>
    /// <param name="start">The start date of the range.</param>
    /// <param name="end">The end date of the range (exclusive).</param>
    /// <returns>The total number of business days between the specified dates.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="end"/> is earlier than <paramref name="start"/>.
    /// </exception>
    /// <remarks>
    /// This method excludes weekends (Saturdays and Sundays) from the count of business days.
    /// </remarks>
    public static int GetBusinessDays(DateTime start, DateTime end)
    {
        int businessDays = 0;
        for (var date = start; date < end; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                businessDays++;
            }
        }
        return businessDays;
    }

}