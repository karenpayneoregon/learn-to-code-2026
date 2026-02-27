namespace CommonHelpersLibrary.LanguageExtensions;

public static class DateExtensions
{
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

}
