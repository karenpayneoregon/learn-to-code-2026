using CommonHelpersLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
