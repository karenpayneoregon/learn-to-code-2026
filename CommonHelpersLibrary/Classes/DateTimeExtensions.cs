using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelpersLibrary.Classes;
public static class DateTimeExtensions
{
    /// <summary>
    /// Generates a list of <see cref="DateTime"/> objects by adding the specified number of weeks to the given date.
    /// </summary>
    /// <param name="date">The starting <see cref="DateTime"/> value.</param>
    /// <param name="weeks">The number of weeks to add. Each week is considered as 7 days.</param>
    /// <returns>A list of <see cref="DateTime"/> objects, where each entry represents a date incremented by 7 days from the starting date.</returns>
    /// <remarks>
    /// This method calculates dates by adding multiples of 7 days to the provided starting date.
    /// </remarks>
    public static List<DateTime> AddWeeks(this DateTime date, int weeks)
    {
        var dates = new List<DateTime>();
        for (int index = 0; index < weeks; index++)
        {
            dates.Add(date.AddDays(index * 7));
        }
        return dates;
    }
}