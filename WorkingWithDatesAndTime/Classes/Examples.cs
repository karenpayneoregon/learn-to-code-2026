using System.Diagnostics;
using System.Globalization;
using CommonHelpersLibrary.Classes;
using System.Text;
using CommonHelpersLibrary.LanguageExtensions;
using WorkingWithDatesAndTime.Data;

namespace WorkingWithDatesAndTime.Classes;
internal static class Examples
{

    /// <summary>
    /// Demonstrates various types and structures used for working with dates and times in .NET.
    /// </summary>
    /// <remarks>
    /// This method provides examples of using <see cref="DateTime"/>, <see cref="DateTimeOffset"/>, 
    /// <see cref="DateOnly"/>, and <see cref="TimeOnly"/> to represent and manipulate date and time values.
    /// It includes examples of creating specific dates, times, and offsets.
    /// </remarks>
    public static void Types()
    {
        // Extracting the day component from the current date and time using deconstruction
        var (_, _, day) = DateTime.Now;
        Debug.WriteLine(day);
        
        DateTime utcNow = DateTime.UtcNow;
        DateTime today = DateTime.Today;
        DateTime specificDate = new DateTime(2025, 12, 25);
        DateTime dateAndTime = new DateTime(2025, 12, 25, 10, 30, 0);
        
        DateTimeOffset dateTimeOffset = new DateTimeOffset(2025, 12, 25, 10, 30, 0, 
            TimeSpan.FromHours(-5));
        
        DateOnly dateOnly = new DateOnly(2025, 12, 25);
        TimeOnly timeOnly = new TimeOnly(10, 30, 0);
        
        TimeSpan timeSpan = new TimeSpan(1, 30, 0); // 1 hour and 30 minutes
    }

    /// <summary>
    /// Generates a formatted string displaying the number of days in each month
    /// for specified years, based on the current culture and calendar.
    /// </summary>
    /// <returns>
    /// A string containing a table-like format where each row represents a year and month,
    /// along with the corresponding number of days in that month.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="DateTime.DaysInMonth(int, int)"/> method to calculate
    /// the number of days in each month for the given years. The output is formatted
    /// according to the current culture and calendar.
    /// </remarks>
    public static string DaysInMonth()
    {
        var sb = new StringBuilder();

        int[] years = [2025, 2026];
        
        DateTimeFormatInfo info = DateTimeFormatInfo.CurrentInfo;
        
        sb.AppendLine($"Days in the Month for the {CultureInfo.CurrentCulture.Name} culture " + 
                      $"using the {info.Calendar.GetType().Name.Replace("Calendar", "")} calendar\n");
        
        sb.Append($"{"Year",-10}{"Month",-15}{"Days",4}").AppendLine();

        foreach (var year in years)
        {
            for (int month = 0; month <= info.MonthNames.Length - 1; month++)
            {
                if (string.IsNullOrEmpty(info.MonthNames[month])) 
                    continue;

                sb.AppendLine($"{year,-10}{info.MonthNames[month],-15}{DateTime.DaysInMonth(year, month + 1),4}");
            }

            sb.AppendLine();
            
        }
        
        return sb.ToString();
        
    }

    /// <summary>
    /// Demonstrates the addition and subtraction of days, months, and years to/from specific dates.
    /// </summary>
    /// <returns>
    /// A formatted string containing examples of date manipulations, including adding days, months, and years,
    /// as well as subtracting days and years from given dates.
    /// </returns>
    /// <remarks>
    /// This method showcases the use of <see cref="DateTime.AddDays(double)"/>, <see cref="DateTime.AddMonths(int)"/>, 
    /// and <see cref="DateTime.AddYears(int)"/> methods to perform various date arithmetic operations.
    /// </remarks>
    public static string DateAddSubtract()
    {
        var sb = new StringBuilder();

        DateTime firstDate = new DateTime(2001, 4, 19);
        DateTime otherDate = new DateTime(1991, 6, 5);
        
        sb.AppendLine($"First date: {firstDate:G} Other date: {otherDate:G}");

        // Add 5 days to firstDate
        DateTime addedDate = firstDate.AddDays(5);
        sb.AppendLine($"First date + 5 days: {addedDate:G}");

        // Subtract 10 days from otherDate
        DateTime subtractedDate = otherDate.AddDays(-10);
        sb.AppendLine($"Other date - 10 days: {subtractedDate:G}");

        // Add 2 months to firstDate
        DateTime addedMonths = firstDate.AddMonths(2);
        
        sb.AppendLine($"First date + 2 months: {addedMonths:G}");

        // Subtract 3 years from otherDate
        DateTime subtractedYears = otherDate.AddYears(-3);
        sb.AppendLine($"Other date - 3 years: {subtractedYears:G}");

        // Add 1 year and 3 months to firstDate
        DateTime addedComplex = firstDate
            .AddYears(1)
            .AddMonths(3);
        
        sb.AppendLine($"First date + 1 year and 3 months: {addedComplex:G}");

        return sb.ToString();
    }

    /// <summary>
    /// Demonstrates the addition of various time intervals (days, months, years) to a specific date
    /// and provides formatted results.
    /// </summary>
    /// <returns>
    /// A formatted string that includes the original date and the results of adding different 
    /// time intervals (e.g., days, months, years) to it.
    /// </returns>
    /// <remarks>
    /// This method showcases the usage of <see cref="DateTime.AddDays(double)"/>, 
    /// <see cref="DateTime.AddMonths(int)"/>, <see cref="DateTime.AddYears(int)"/>, 
    /// and <see cref="DateTime.Add(TimeSpan)"/> methods to manipulate dates.
    /// </remarks>
    public static string DateAddMethod()
    {
        var sb = new StringBuilder();

        DateTime date = new(2001, 4, 19);

        sb.AppendLine($"Original date: {date:G}");

        // Add 5 days to the date
        DateTime addedDays = date.AddDays(5);
        sb.AppendLine($"Date after adding 5 days: {addedDays:G}");

        // Add 2 months to the date
        DateTime addedMonths = date.AddMonths(2);
        sb.AppendLine($"Date after adding 2 months: {addedMonths:G}");

        // Add 1 year to the date
        DateTime addedYears = date.AddYears(1);
        sb.AppendLine($"Date after adding 1 year: {addedYears:G}");

        // Add 1 year and 3 months to the date
        DateTime addedComplex = date
            .AddYears(1)
            .AddMonths(3);
        sb.AppendLine($"Date after adding 1 year and 3 months: {addedComplex:G}");

        // Add 365 days to the date (equivalent to a year, but accounts for leap years)
        DateTime addedDaysEquivalentToYear = date.AddDays(365);
        sb.AppendLine($"Date after adding 365 days: {addedDaysEquivalentToYear:G}");

        // Calculate what day of the week is 36 days from this instant.
        DateTime today = DateTime.Now;
        TimeSpan duration = new TimeSpan(36, 0, 0, 0);
        DateTime answer = today.Add(duration);
        
        sb.AppendLine($"36 days from today ({today:MMMM dd, yyyy}) is a {answer:dddd}.");
        
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

        bool areEqual = firstDate.Equals(otherDate);
        sb.AppendLine($"Are they equal? {areEqual.ToYesNo()}");

        otherDate = new DateTime(2001, 4, 19);

        sb.AppendLine($"First date: {firstDate:MM/dd/yyyy} Other date: {otherDate:MM/dd/yyyy}");
        areEqual = firstDate == otherDate;
        sb.AppendLine($"Are they equal? {areEqual.ToYesNo()}");


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

    /// <summary>
    /// Compares two <see cref="DateTime"/> values to determine if one is greater than the other
    /// and returns the result as a formatted string.
    /// </summary>
    /// <returns>
    /// A string containing the details of the comparison, including the values of the two dates
    /// and whether the first date is greater than the second date.
    /// </returns>
    /// <remarks>
    /// This method demonstrates the use of the greater-than operator (<c>&gt;</c>) for comparing
    /// <see cref="DateTime"/> values. It also includes an example where the time component of a
    /// <see cref="DateTime"/> is considered during the comparison.
    /// </remarks>
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

        int result = DateTime.Compare(firstDate, otherDate);
        sb.AppendLine($"Comparison result using DateTime.Compare: {result}");

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
    /// Retrieves and processes dates for the current month, including weekend dates and workdays.
    /// </summary>
    /// <remarks>
    /// This method utilizes the <see cref="CommonHelpersLibrary.Classes.DateHelper.GetWeekendDates(int, int)"/> 
    /// and <see cref="CommonHelpersLibrary.Classes.DateHelper.GetWorkDays(int, int)"/> methods to identify 
    /// weekend dates (Saturdays and Sundays) and workdays (Monday through Friday) for the current month.
    /// </remarks>
    private static void GetDatesForCurrentMonth()
    {
        List<DateOnly> weekendDates = DateHelper
            .GetWeekendDates(DateTime.Now.Year, DateTime.Now.Month);

        List<DateOnly> workDays = DateHelper
            .GetWorkDays(DateTime.Now.Year, DateTime.Now.Month);
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

        Dictionary<DateOnly, List<DateOnly>> result = 
            DateHelper.GetWorkDaysGroupedByWeek(start, end);

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
                    sb.AppendLine($"{holiday.CalendarDate:MM/dd/yyyy}: {holiday.CalendarDateDescription} {holiday.Weekend.IsWeekend()}  *");
                }
                else
                {
                    sb.AppendLine($"{holiday.CalendarDate:MM/dd/yyyy}: {holiday.CalendarDateDescription} {holiday.Weekend.IsWeekend()}");
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
    /// Demonstrates various ways to format a <see cref="DateTime"/> object into different string representations.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> containing examples of formatted date and time values using standard and custom format specifiers.
    /// </returns>
    /// <remarks>
    /// This method showcases the use of standard date and time format strings (e.g., "d", "D", "f", "F", "g", etc.)
    /// as well as custom format strings (e.g., "yyyy-MM-dd HH:mm:ss", "ddd, MMM d, yyyy", etc.).
    /// It also includes examples of extracting specific components like the month, day, and year.
    ///
    /// Microsoft documentation on date and time format strings can be found at:
    /// https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
    /// </remarks>
    public static string FormatDateTimeExamples()
    {

        var sb = new StringBuilder();
        
        var date = new DateTime(2026, 6, 15, 14, 30, 45);

        sb.AppendLine($"Original date: {date:G}");
        sb.AppendLine($"Date in short date format: {date:d}");
        sb.AppendLine($"Date in long date format: {date:D}");
        sb.AppendLine($"Date and time in short format: {date:f}");
        sb.AppendLine($"Date and time in long format: {date:F}");
        sb.AppendLine($"Date and time in general format: {date:g}");
        sb.AppendLine($"Date and time in general (short time) format: {date:G}");
        sb.AppendLine($"Month and day format: {date:m}");
        sb.AppendLine($"Month and year format: {date:y}");
        sb.AppendLine($"Custom format (yyyy-MM-dd HH:mm:ss): {date:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine($"Custom format (ddd, MMM d, yyyy): {date:ddd, MMM d, yyyy}");
        sb.AppendLine($"Custom format (h:mm tt): {date:h:mm tt}");
        sb.AppendLine($"Abbreviated month name: {date:MMM}");
        sb.AppendLine($"Full month name: {date:MMMM}");
        sb.AppendLine($"Abbreviated day name: {date:ddd}");
        sb.AppendLine($"Full day name: {date:dddd}");
        sb.AppendLine($"Two-digit day: {date:dd}");
        sb.AppendLine($"Two-digit month: {date:MM}");
        sb.AppendLine($"Four-digit year: {date:yyyy}");
        sb.AppendLine($"Two-digit year: {date:yy}");
        sb.AppendLine($"AM/PM marker: {date:t}"); // Equivalent to 'tt' for AM/PM
        sb.AppendLine($"AM/PM marker (long): {date:tt}");
        
        return sb.ToString();

    }
    
    /// <summary>
    /// Retrieves a list of leap years within a predefined range.
    /// </summary>
    /// <returns>
    /// A list of integers representing the leap years between 2000 and 2026, inclusive.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="DateTime.IsLeapYear(int)"/> method to determine whether a year is a leap year.
    /// </remarks>
    public static List<int> GetLeapYearsOnly() =>
        Enumerable.Range(2000, 27)
            .Where(DateTime.IsLeapYear)
            .ToList();

    /// <summary>
    /// Generates a greeting message based on the specified date and time.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> object representing the date and time for which the greeting is generated.</param>
    /// <returns>
    /// A string containing a day-specific greeting message. For example, "Happy Monday!" for Monday or "Enjoy your Saturday!" for Saturday.
    /// </returns>
    /// <remarks>
    /// The method evaluates the <see cref="DateTime.DayOfWeek"/> property of the provided <paramref name="dateTime"/>
    /// to determine the appropriate greeting message.
    /// </remarks>
    public static string GetGreeting(DateTime dateTime) =>
        dateTime.DayOfWeek switch
        {
            DayOfWeek.Monday => "Happy Monday!",
            DayOfWeek.Tuesday => "Taco Tuesday!",
            DayOfWeek.Wednesday => "Happy Wednesday!",
            DayOfWeek.Thursday => "Happy Thursday!",
            DayOfWeek.Friday => "Happy Friday!",
            DayOfWeek.Saturday => "Enjoy your Saturday!",
            DayOfWeek.Sunday => "Relax, it's Sunday!",
            _ => "Hello!"
        };

    /// <summary>
    /// Generates a raw string literal containing a personalized greeting message.
    /// </summary>
    /// <returns>
    /// A raw string literal that includes the user's name and the current date, 
    /// along with a day-specific greeting message.
    /// </returns>
    /// <remarks>
    /// The method uses a raw string literal to format the output, incorporating the 
    /// current user's name (<see cref="Environment.UserName"/>) and the current date 
    /// (<see cref="DateTime.Now"/>). It also calls the <see cref="GetGreeting(DateTime)"/> 
    /// method to include a greeting based on the current day of the week.
    /// </remarks>
    public static string RawStringLiteral()
    {
        return $"""
                Hello {Environment.UserName} on {DateTime.Now:MMMM dd, yyyy}!
                {GetGreeting(DateTime.Now)}
                """;
    }

    /// <summary>
    /// Demonstrates working with time zones by creating a <see cref="DateTimeOffset"/> instance
    /// using a specific date, time, and time zone.
    /// </summary>
    /// <remarks>
    /// This method initializes a <see cref="DateTime"/> object with a specific date and time,
    /// retrieves the Pacific Standard Time zone using <see cref="TimeZoneInfo.FindSystemTimeZoneById(string)"/>,
    /// and calculates the UTC offset for the given date and time. The result is used to create
    /// a <see cref="DateTimeOffset"/> instance.
    /// </remarks>
    public static string PacificTimeZone()
    {
        var dt =  DateTime.Now;

        var pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        var pacificOffset = new DateTimeOffset(dt, pacificZone.GetUtcOffset(dt));
        
        return pacificOffset.ToString("yyyy-MM-dd HH:mm:ss zzz");
    }

    /// <summary>
    /// Retrieves the current date and time in the Eastern Time Zone as a formatted string.
    /// </summary>
    /// <returns>
    /// A string representing the current date and time in the "Eastern Standard Time" zone,
    /// formatted as "yyyy-MM-dd HH:mm:ss zzz".
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="TimeZoneInfo.FindSystemTimeZoneById(string)"/> method
    /// to obtain the "Eastern Standard Time" zone and converts the current time to this time zone
    /// using <see cref="TimeZoneInfo.ConvertTime(DateTimeOffset, TimeZoneInfo)"/>.
    /// </remarks>
    public static string EasternTimeZone()
    {
        // safer: start with a DateTimeOffset and convert to Eastern time
        var nowDto = DateTimeOffset.Now;
        var eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var easternTime = TimeZoneInfo.ConvertTime(nowDto, eastern);
        return easternTime.ToString("yyyy-MM-dd HH:mm:ss zzz");
    }

    /// <summary>
    /// Calculates and displays the age in years based on a given date of birth.
    /// </summary>
    /// <remarks>
    /// This method demonstrates how to calculate the age in years by subtracting a date of birth
    /// from the current date. It uses <see cref="DateOnly"/> and <see cref="TimeSpan"/> for date manipulation.
    /// The result is logged using <see cref="Debug.WriteLine(string)"/>.
    /// </remarks>
    public static void GetAge1()
    {
        var dob = new DateOnly(1956, 9, 24); // Date of Birth
        var today = DateOnly.FromDateTime(DateTime.Today);

        TimeSpan ageSpan = today.ToDateTime(TimeOnly.Parse("00:00:00")) - 
                           dob.ToDateTime(TimeOnly.Parse("00:00:00"));
        
        int years = DateTime.MinValue.AddDays(ageSpan.TotalDays).Year - 1;

        Debug.WriteLine($"Date of Birth: {dob}");
        Debug.WriteLine($"Today: {today}");
        Debug.WriteLine($"Age: {years} years");
    }

    /// <summary>
    /// Calculates and logs the age based on a hardcoded date of birth.
    /// </summary>
    /// <remarks>
    /// This method calculates the age by subtracting the date of birth (hardcoded as September 24, 1956) 
    /// from the current date. The result is divided by 10000 to determine the age in years.
    /// The method logs the current date, the date of birth, and the calculated age using <see cref="Debug.WriteLine"/>.
    /// </remarks>
    public static void GetAge2()
    {
        int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        int dob = int.Parse(new DateTime(1956, 9, 24).ToString("yyyyMMdd"));
        int age = (now - dob) / 10000;
        
        Debug.WriteLine($"Now: {now}");
        Debug.WriteLine($"Date of Birth: {dob}");
        Debug.WriteLine($"Age: {age} years");
    }

    /// <summary>
    /// Retrieves calendar data for a specific year from the database.
    /// </summary>
    /// <remarks>
    /// This method queries the database for calendar entries where the year matches 2099.
    /// The results are ordered in descending order by the calendar year.
    /// </remarks>
    /// <example>
    /// <code>
    /// Examples.Calendar();
    /// </code>
    /// </example>
    public static void Calendar()
    {
        using var context = new Context();
        var item = context.Calendar
            .OrderByDescending(x => x.CalendarYear)
            .Where(x => x.CalendarYear == 2099)
            .ToList();
    }

    public static string AddWeeksExample()
    {
        var sb = new StringBuilder();

        var dateTime = DateTime.Now;

        sb.AppendLine($"startDate.AddWeeks(-1) {dateTime.AddWeeks(-1):MM/dd/yyyy}");
        sb.AppendLine($" startDate.AddWeeks(1) {dateTime.AddWeeks(1):MM/dd/yyyy}");

        return sb.ToString();
    }
}
