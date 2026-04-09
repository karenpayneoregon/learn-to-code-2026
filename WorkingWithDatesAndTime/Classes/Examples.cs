using CommonHelpersLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithDatesAndTime.Data;

namespace WorkingWithDatesAndTime.Classes;
internal class Examples
{
    private static void GetDatesForCurrentMonth()
    {
        List<DateOnly> weekendDates = DateHelper.GetWeekendDates(DateTime.Now.Year, DateTime.Now.Month);
        List<DateOnly> workDays = DateHelper.GetWorkDays(DateTime.Now.Year, DateTime.Now.Month);
    }

    /// <summary>
    /// Groups workdays of the current month by the starting date of each week and returns the result as a formatted string.
    /// </summary>
    /// <returns>
    /// A string where each line represents a week, starting with the Monday of that week, followed by the workdays
    /// within that week.
    /// </returns>
    /// <remarks>
    /// This method uses the current year and month to determine the date range and utilizes the
    /// <see cref="DateHelper.GetWorkDaysGroupedByWeek(DateOnly, DateOnly)"/> method
    /// to group the workdays. The result is formatted into a human-readable string.
    /// </remarks>
    public static string GroupWorkDaysByWeek()
    {
        var year = DateTime.Now.Year;
        var month = DateTime.Now.Month;

        var start = new DateOnly(year, month, 1);
        var end = new DateOnly(year, month, 30);

        Dictionary<DateOnly, List<DateOnly>> result = DateHelper.GetWorkDaysGroupedByWeek(start, end);
        
        StringBuilder sb = new();
        foreach (var (dateOnly, value) in result)
        {
            sb.AppendLine($"Week starting {dateOnly:MM/dd/yyyy}: {string.Join(", ", value)}");
        }
        
        return sb.ToString();
    }

    /// <summary>
    /// Retrieves a list of holidays for the current year from the database and formats them as a string.
    /// </summary>
    /// <returns>
    /// A formatted string containing the holidays of the current year. Each holiday is displayed with its date
    /// and description. Holidays in the current month are marked with an asterisk (*).
    /// </returns>
    /// <remarks>
    /// This method queries the database using the <see cref="Context"/> class to fetch holidays for the current year.
    /// If no holidays are found, the method returns a message indicating that no holidays are available.
    /// </remarks>
    public static string CurrentYearHolidays()
    {
        using var context = new Context();
        var holidays = context.Calendar
            .Where(c => c.Holiday && c.CalendarYear == DateTime.Now.Year)
            .ToList();

        var sb = new StringBuilder();

        sb.AppendLine($"--- Holidays for {DateTime.Now.Year} ---");
        sb.AppendLine();

        if (holidays.Any())
        {
            var month = DateTime.Now.Month;

            foreach (var holiday in holidays.OrderBy(h => h.CalendarDate))
            {
                if (holiday.CalendarMonth == month)
                {
                    sb.AppendLine($"{holiday.CalendarDate:MM/dd/yyyy}: {holiday.CalendarDateDescription}  *");
                }
                else
                {
                    sb.AppendLine($"{holiday.CalendarDate:MM/dd/yyyy}: {holiday.CalendarDateDescription}");
                }
            }
        }
        else
        {
            sb.AppendLine("No holidays found for the current year.");
        }


        return sb.ToString();

    }

    /// <summary>
    /// Compares two <see cref="DateTime"/> objects for equality and returns the result as a formatted string.
    /// </summary>
    /// <returns>
    /// A string containing the details of the two dates being compared, along with the result of the equality check.
    /// </returns>
    /// <remarks>
    /// This method demonstrates the equality comparison of <see cref="DateTime"/> objects by comparing two dates.
    /// It uses the <see cref="BoolExtensions.ToYesNo(bool)"/> extension method to format the comparison result
    /// as "Yes" or "No".
    /// </remarks>
    public static string DateEquality()
    {
        var sb = new StringBuilder();

        DateTime firstDate = new DateTime(2001, 4, 19);
        DateTime otherDate = new DateTime(1991, 6, 5);
        
        sb.AppendLine($"First date: {firstDate:MM/dd/yyyy} Other date: {otherDate:MM/dd/yyyy}");

        bool areEqual = firstDate == otherDate;
        sb.AppendLine($"Are they equal? {areEqual.ToYesNo()}");

        otherDate = new DateTime(2001, 4, 19);

        sb.AppendLine($"First date: {firstDate:MM/dd/yyyy} Other date: {otherDate:MM/dd/yyyy}");
        areEqual = firstDate == otherDate;
        sb.AppendLine($"Are they equal? {areEqual.ToYesNo()}");


        return sb.ToString();
    }

    public static string DateGreaterThan()
    {
        var sb = new StringBuilder();

        DateTime firstDate = new DateTime(2001, 4, 19);
        DateTime otherDate = new DateTime(1991, 6, 5);

        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");

        bool isGreaterThan = firstDate > otherDate;
        sb.AppendLine($"Is first date greater than other date? {isGreaterThan.ToYesNo()}");

        otherDate = new DateTime(2001, 4, 19, 12, 0, 10); // Add time component

        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");
        isGreaterThan = firstDate > otherDate;
        sb.AppendLine($"Is first date greater than other date? {isGreaterThan.ToYesNo()}");


        return sb.ToString();
    }

    /// <summary>
    /// Compares two <see cref="DateTime"/> objects for less than or equal to relationship and returns the result as a formatted string.
    /// </summary>
    /// <returns>
    /// A string containing the details of the two dates being compared, along with the result of the less than or equal to check.
    /// </returns>
    /// <remarks>
    /// This method demonstrates the less than or equal to comparison of <see cref="DateTime"/> objects by comparing two dates.
    /// It uses the <see cref="BoolExtensions.ToYesNo(bool)"/> extension method to format the comparison result
    /// as "Yes" or "No".
    /// </remarks>
    public static string DateLessThanOrEqual()
    {
        var sb = new StringBuilder();

        DateTime firstDate = new DateTime(2001, 4, 19);
        DateTime otherDate = new DateTime(1991, 6, 5);

        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");

        bool isLessThanOrEqual = firstDate <= otherDate;
        sb.AppendLine($"Is first date less than or equal to other date? {isLessThanOrEqual.ToYesNo()}");

        otherDate = new DateTime(2001, 4, 19); // Equal dates

        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");
        isLessThanOrEqual = firstDate <= otherDate;
        sb.AppendLine($"Is first date less than or equal to other date? {isLessThanOrEqual.ToYesNo()}");

        otherDate = new DateTime(2001, 4, 19, 12, 0, 10); // Other date is later

        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");
        isLessThanOrEqual = firstDate <= otherDate;
        sb.AppendLine($"Is first date less than or equal to other date? {isLessThanOrEqual.ToYesNo()}");

        return sb.ToString();
    }

    /// <summary>
    /// Compares two <see cref="DateTime"/> objects for greater than or equal to relationship and returns the result as a formatted string.
    /// </summary>
    /// <returns>
    /// A string containing the details of the two dates being compared, along with the result of the greater than or equal to check.
    /// </returns>
    /// <remarks>
    /// This method demonstrates the greater than or equal to comparison of <see cref="DateTime"/> objects by comparing two dates.
    /// It uses the <see cref="BoolExtensions.ToYesNo(bool)"/> extension method to format the comparison result
    /// as "Yes" or "No".
    /// </remarks>
    public static string DateGreaterThanOrEqual()
    {
        var sb = new StringBuilder();

        DateTime firstDate = new DateTime(2001, 4, 19);
        DateTime otherDate = new DateTime(1991, 6, 5);

        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");

        bool isGreaterThanOrEqual = firstDate >= otherDate;
        sb.AppendLine($"Is first date greater than or equal to other date? {isGreaterThanOrEqual.ToYesNo()}");

        otherDate = new DateTime(2001, 4, 19); // Equal dates

        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");
        isGreaterThanOrEqual = firstDate >= otherDate;
        sb.AppendLine($"Is first date greater than or equal to other date? {isGreaterThanOrEqual.ToYesNo()}");

        otherDate = new DateTime(2001, 4, 19, 12, 0, 10); // Other date is later

        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");
        isGreaterThanOrEqual = firstDate >= otherDate;
        sb.AppendLine($"Is first date greater than or equal to other date? {isGreaterThanOrEqual.ToYesNo()}");

        return sb.ToString();
    }

    /// <summary>
    /// Compares two <see cref="DateTime"/> objects for inequality and returns the result as a formatted string.
    /// </summary>
    /// <returns>
    /// A string containing the details of the two dates being compared, along with the result of the inequality check.
    /// </returns>
    /// <remarks>
    /// This method demonstrates the inequality comparison of <see cref="DateTime"/> objects by comparing two dates.
    /// It uses the <see cref="BoolExtensions.ToYesNo(bool)"/> extension method to format the comparison result
    /// as "Yes" or "No".
    /// </remarks>
    public static string DateInequality()
    {
        var sb = new StringBuilder();

        DateTime firstDate = new DateTime(2001, 4, 19);
        DateTime otherDate = new DateTime(1991, 6, 5);

        sb.AppendLine($"First date: {firstDate:MM/dd/yyyy} Other date: {otherDate:MM/dd/yyyy}");

        bool areNotEqual = firstDate != otherDate;
        sb.AppendLine($"Are they not equal? {areNotEqual.ToYesNo()}");

        otherDate = new DateTime(2001, 4, 19);

        sb.AppendLine($"First date: {firstDate:MM/dd/yyyy} Other date: {otherDate:MM/dd/yyyy}");
        areNotEqual = firstDate != otherDate;
        sb.AppendLine($"Are they not equal? {areNotEqual.ToYesNo()}");

        return sb.ToString();
    }
}
