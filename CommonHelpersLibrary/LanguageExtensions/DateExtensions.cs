using System.Globalization;

namespace CommonHelpersLibrary.LanguageExtensions;

public static class DateExtensions
{

    /// <summary>
    /// Adds the specified number of weeks to the given <see cref="DateTime"/> instance.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> instance to which the weeks will be added.</param>
    /// <param name="numberOfWeeks">The number of weeks to add. Can be positive or negative.</param>
    /// <returns>A new <see cref="DateTime"/> instance that is the result of adding the specified number of weeks to the original date.</returns>
    public static DateTime AddWeeks(this DateTime dateTime, int numberOfWeeks)
    {
        var (year, month, day) = dateTime;
        DateTime dt = new DateTime(year, month, day, new GregorianCalendar());
        Calendar cal = CultureInfo.InvariantCulture.Calendar;
        return cal.AddWeeks(dt, numberOfWeeks);
    }

    public static DateTime AddWeeks1(this DateTime dateTime, int numberOfWeeks)
        => dateTime.AddDays(numberOfWeeks * 7);

    /// <summary>
    /// Adds the specified number of business days to the given <see cref="DateTime"/> instance.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> instance to which the business days will be added.</param>
    /// <param name="days">The number of business days to add. Can be positive or negative.</param>
    /// <returns>A new <see cref="DateTime"/> instance that is the result of adding the specified number of business days to the original date.</returns>
    /// <remarks>
    /// Business days are considered as Monday through Friday. Weekends (Saturday and Sunday) are skipped.
    /// </remarks>
    public static DateTime AddBusinessDays(this DateTime dateTime, int days)
    {
        if (days == 0)
            return dateTime;

        int direction = days > 0 ? 1 : -1;

        // Move full weeks
        int absDays = Math.Abs(days);
        int fullWeeks = absDays / 5;
        dateTime = dateTime.AddDays(fullWeeks * 7 * direction);

        int remainingDays = absDays % 5;

        while (remainingDays > 0)
        {
            dateTime = dateTime.AddDays(direction);

            if (!dateTime.IsWeekend())
            {
                remainingDays--;
            }
        }

        return dateTime;
    }

    public static DateTime AddBusinessDays(DateTime current, int days, IEnumerable<DateTime> holidays = null!)
    {
        var sign = Math.Sign(days);
        var unsignedDays = Math.Abs(days);
        // Loop through days, skipping weekends and holidays
        for (var i = 0; i < unsignedDays; i++)
        {
            do { current = current.AddDays(sign); }
            while (current.DayOfWeek == DayOfWeek.Saturday ||
                   current.DayOfWeek == DayOfWeek.Sunday ||
                   (holidays != null && holidays.Contains(current.Date)));
        }
        return current;
    }


    /// <summary>
    /// Adds the specified number of business days to the given <see cref="DateOnly"/> instance.
    /// </summary>
    /// <param name="date">The <see cref="DateOnly"/> instance to which the business days will be added.</param>
    /// <param name="days">The number of business days to add. Can be positive or negative.</param>
    /// <returns>A new <see cref="DateOnly"/> instance that is the result of adding the specified number of business days to the original date.</returns>
    /// <remarks>
    /// Business days are considered as Monday through Friday. Weekends (Saturday and Sunday) are skipped.
    /// </remarks>
    public static DateOnly AddBusinessDays(this DateOnly date, int days)
    {

        //TODO add holiday exclusions

        int fullWeeks = days / 5;
        date = date.AddDays(fullWeeks * 7);

        int remainingDays = days % 5;

        for (int index = 0; index < remainingDays; index++)
        {
            date = date.DayOfWeek switch
            {
                DayOfWeek.Friday => date.AddDays(3),
                DayOfWeek.Saturday => date.AddDays(2),
                _ => date.AddDays(1)
            };
        }

        return date;
    }

    /// <summary>
    /// Calculates the age based on the provided date of birth.
    /// </summary>
    /// <param name="dob">The date of birth as a <see cref="DateTime"/>.</param>
    /// <returns>The calculated age as an <see cref="int"/>.</returns>
    public static int GetAge(this DateTime dob)
    {
        var today = DateTime.Today;

        int age = today.Year - dob.Year;

        // If birthday hasn't occurred yet this year, subtract 1
        if (today.Month < dob.Month || today.Month == dob.Month && today.Day < dob.Day)
        {
            age--;
        }

        return age;
    }

    /// <summary>
    /// Calculates the age based on the provided nullable date of birth.
    /// </summary>
    /// <param name="dob">The nullable date of birth as a <see cref="DateTime?"/>.</param>
    /// <returns>The calculated age as an <see cref="int"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="dob"/> is <c>null</c>.</exception>
    public static int GetAge(this DateTime? dob)
    {
        if (!dob.HasValue)
            throw new ArgumentNullException(nameof(dob), "Date of birth cannot be null.");

        var today = DateTime.Today;
        var value = dob.Value;

        int age = today.Year - value.Year;

        // If birthday hasn't occurred yet this year, subtract 1
        if (today.Month < value.Month || today.Month == value.Month && today.Day < value.Day)
        {
            age--;
        }

        return age;
    }

    /// <summary>
    /// Calculates the age based on the provided date of birth.
    /// </summary>
    /// <param name="dob">The date of birth as a <see cref="DateOnly"/>.</param>
    /// <returns>The calculated age as an <see cref="int"/>.</returns>
    public static int GetAge(this DateOnly dob)
    {
        var (nYear, nMonth, nDay) = DateTime.Today;

        var a = (nYear * 100 + nMonth) * 100 + nDay;
        var (bYear, bMonth, bDay) = dob;
        var b = (bYear * 100 + bMonth) * 100 + bDay;

        return (a - b) / 10000;
    }

    public static bool IsWeekend(this DateTime sender) 
        => sender.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday;

}
