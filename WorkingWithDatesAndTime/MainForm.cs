
using System.Text;
using WorkingWithDatesAndTime.Classes;
using WorkingWithDatesAndTime.Data;

// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace WorkingWithDatesAndTime;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

    }

    private void DateTimeTryParseButton_Click(object sender, EventArgs e)
    {
        List<string> datesList =
        [
            "04/09/2026 13:35", // valid date string in MM/dd/yyyy format
            "0409/2026 13:35", // bad date time format
            "2026-09-04 13:35:00"
        ];

        StringBuilder sb = new();
        foreach (var item in datesList)
        {
            if (DateTime.TryParse(item, out DateTime parsedDate))
            {
                sb.AppendLine($"Parsed date: {parsedDate}");
            }
            else
            {
                sb.AppendLine($"Failed to parse {item}.");
            }
        }


        ResultsTextBox.Text = sb.ToString();

        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();

    }

    /// <summary>
    /// Demonstrates the usage of deconstruction with <see cref="DateTime"/>, <see cref="DateOnly"/>, 
    /// <see cref="TimeOnly"/>, and <see cref="TimeSpan"/> objects.
    /// </summary>
    private void DeconstructButton_Click(object sender, EventArgs e)
    {

        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.datetime.deconstruct?view=net-8.0
            var ((year, month, day), (hour, minute, second)) = DateTime.Now;
        }

        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.dateonly.deconstruct?view=net-8.0
            var (year, month, day) = new DateOnly(2026, 4, 9);
        }

        // https://learn.microsoft.com/en-us/dotnet/api/system.timeonly.deconstruct?view=net-8.0
        // https://learn.microsoft.com/en-us/dotnet/api/system.timeonly.fromdatetime?view=net-8.0
        var (h, m, s) = TimeOnly.FromDateTime(DateTime.Now);
        var (hours, mins, secs) = TimeSpan.FromMinutes(125);
    }

    private void GroupWorkDaysByWeekButton_Click(object sender, EventArgs e)
    {
        ResultsTextBox.Text = Examples.GroupWorkDaysByWeek();
        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();
    }

    private void HolidaysButton_Click(object sender, EventArgs e)
    {
        ResultsTextBox.Text = Examples.CurrentYearHolidays();
        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();
    }

    /// <summary>
    /// This method processes a predefined list of date strings in various formats, 
    /// attempting to parse them into <see cref="DateTime"/> objects using specific parsing logic.
    /// Results of the parsing operation are displayed in the ResultsTextBox.
    /// </summary>
    private void TryParseExactButton_Click(object sender, EventArgs e)
    {
        List<string> testInputs =
        [
            "3/5/2024", // M/d/yyyy
            "03/05/2024", // MM/dd/yyyy
            "5/3/2024", // d/M/yyyy
            "05/03/2024", // dd/MM/yyyy
            "2024/3/5", // yyyy/M/d
            "2024/03/05", // yyyy/MM/dd

            // --- Valid: Dash formats ---
            "3-5-2024", // M-d-yyyy
            "03-05-2024", // MM-dd-yyyy
            "5-3-2024", // d-M-yyyy
            "05-03-2024", // dd-MM-yyyy
            "2024-3-5", // yyyy-M-d
            "2024-03-05", // yyyy-MM-dd

            // --- Valid: Dot formats ---
            "3.5.2024", // M.d.yyyy
            "03.05.2024", // MM.dd.yyyy
            "5.3.2024", // d.M.yyyy
            "05.03.2024", // dd.MM.yyyy
            "2024.3.5", // yyyy.M.d
            "2024.03.05", // yyyy.MM.dd

            // --- Valid: Space formats ---
            "3 5 2024", // M d yyyy
            "03 05 2024", // MM dd yyyy
            "5 3 2024", // d M yyyy
            "05 03 2024", // dd MM yyyy
            "2024 3 5", // yyyy M d
            "2024 03 05", // yyyy MM dd

            // --- Valid: Comma formats ---
            "3,5,2024", // M,d,yyyy
            "03,05,2024", // MM,dd,yyyy
            "5,3,2024", // d,M,yyyy
            "05,03,2024", // dd,MM,yyyy
            "2024,3,5", // yyyy,M,d
            "2024,03,05", // yyyy,MM,dd

            // --- Valid: Month name formats ---
            "5-Jan-2024", // d-MMM-yyyy
            "5/Jan/2024", // d/MMM/yyyy
            "5 Jan 2024", // d MMM yyyy
            "5.Jan.2024", // d.MMM.yyyy
            "05-Jan-2024", // dd-MMM-yyyy
            "05/Jan/2024", // dd/MMM/yyyy
            "05 Jan 2024", // dd MMM yyyy
            "05.Jan.2024", // dd.MMM.yyyy
            "Jan/05/2024", // MMM/dd/yyyy
            "Jan-05-2024", // MMM-dd-yyyy
            "Jan 05 2024", // MMM dd yyyy
            "Jan.05.2024", // MMM.dd.yyyy

            // --- Valid: Short year ---
            "5-Jan-4", // d-MMM-y
            "5 Jan 4", // d MMM y

            // --- Invalid: Completely wrong ---
            "not a date",
            "",
            "   ",

            // --- Invalid: Bad numbers ---
            "32/01/2024", // invalid day
            "13/32/2024", // invalid month/day combo
            "2024/13/01", // invalid month
            "2024-00-10", // invalid month
            "2024-02-30", // invalid day for Feb

            // --- Invalid: Wrong separators ---
            "2024|03|05",
            "05*03*2024",

            // --- Invalid: Partial dates ---
            "2024-03",
            "03/2024",
            "2024",

            // --- Invalid: Mixed formats ---
            "2024/03-05",
            "Jan/2024/05",

            // --- Edge cases ---
            "2/29/2024", // valid leap year
            "2/29/2023", // invalid (not leap year)
            "02-29-2024", // valid
            "02-29-2023", // invalid

            // --- Case sensitivity check ---
            "5-jan-2024", // fails (InvariantCulture expects proper casing)
            "5-JAN-2024"
        ];

        StringBuilder sb = new();
        
        DateTimeUtilities dateTimeUtilities = new DateTimeUtilities();
        foreach (var input in testInputs)
        {
            sb.AppendLine(dateTimeUtilities.GetDateFormat(input));
        }
        
        ResultsTextBox.Text = sb.ToString();
        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();
        
    }
}

