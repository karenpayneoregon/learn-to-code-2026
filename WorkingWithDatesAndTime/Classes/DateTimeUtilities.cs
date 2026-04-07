using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace WorkingWithDatesAndTime.Classes;
internal class DateTimeUtilities
{
    /// <summary>
    /// Identifies the format of a given date string by attempting to parse it against a predefined list of date formats.
    /// </summary>
    /// <param name="input">The date string whose format needs to be identified.</param>
    /// <returns>
    /// A string representing the detected date format of the input string.
    /// If no matching format is found, it returns a message indicating that the format is unknown.
    /// </returns>
    /// <remarks>
    /// This method leverages <see cref="DateTime.TryParseExact"/> with a comprehensive set of date formats
    /// and utilizes <see cref="CultureInfo.InvariantCulture"/> to ensure consistent behavior across different cultures.
    /// </remarks>
    public static string GetDateFormat(string input)
    {
        
        var formats = Formats();

        DateTime dateValue;
        foreach ((int index, string format) in formats.Index())
        {
            if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                return $"Input: {input}, Format: {format}";
        }

        return $"Input: {input}, Format: Unknown";
    }

    /// <summary>
    /// Attempts to parse the provided date string into a <see cref="DateTime"/> object
    /// using a predefined list of date formats.
    /// </summary>
    /// <param name="input">The date string to be parsed.</param>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="DateTime"/> Date: The parsed date if the operation is successful; otherwise, the default value of <see cref="DateTime"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="bool"/> Success: A boolean indicating whether the parsing was successful.
    /// </description>
    /// </item>
    /// </list>
    /// </returns>s
    public static (DateTime Date, bool Success) GetDate(string input)
    {
        var formats = Formats();

        foreach (string format in formats)
            if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
                return (dateValue, true);

        return (default, false);
        
    }

    /// <summary>
    /// Provides a predefined list of date formats used for parsing and identifying date strings.
    /// </summary>
    /// <returns>
    /// An array of strings, where each string represents a specific date format.
    /// </returns>
    private static string[] Formats()
    {
        string[] formats =
        [
            "M/d/yyyy", "MM/dd/yyyy",
            "d/M/yyyy", "dd/MM/yyyy",
            "yyyy/M/d", "yyyy/MM/dd",
            "M-d-yyyy", "MM-dd-yyyy",
            "d-M-yyyy", "dd-MM-yyyy",
            "yyyy-M-d", "yyyy-MM-dd",
            "M.d.yyyy", "MM.dd.yyyy",
            "d.M.yyyy", "dd.MM.yyyy",
            "yyyy.M.d", "yyyy.MM.dd",
            "M,d,yyyy", "MM,dd,yyyy",
            "d,M,yyyy", "dd,MM,yyyy",
            "yyyy,M,d", "yyyy,MM,dd",
            "M d yyyy", "MM dd yyyy",
            "d M yyyy", "dd MM yyyy",
            "yyyy M d", "yyyy MM dd",
            "d-MMM-yyyy", "d/MMM/yyyy", "d MMM yyyy", "d.MMM.yyyy",
            "d-MMM-y", "d/MMM/y", "d MMM y", "d.MMM.y",
            "dd-MMM-yyyy", "dd/MMM/yyyy", "dd MMM yyyy", "dd.MMM.yyyy",
            "MMM/dd/yyyy", "MMM-dd-yyyy", "MMM dd yyyy", "MMM.dd.yyyy", "MMM.dd.yyyy"
        ];
        return formats;
    }
}
