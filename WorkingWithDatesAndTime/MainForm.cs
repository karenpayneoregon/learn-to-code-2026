
using System.Diagnostics;
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
        
        Shown += MainForm_Shown;

    }

    private void MainForm_Shown(object? sender, EventArgs e)
    {
        ResultsTextBox.Text = Examples.DaysInMonth();
        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();

        GreetingLabel.Text = Examples.GetGreeting(DateTime.Now);
        
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
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
        }
        
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.datetime.deconstruct?view=net-8.0
            var ((year, month, day), (hour, minute, second)) = DateTime.Now;
        }

        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.datetime.deconstruct?view=net-8.0
            var (year, month, day) = DateTime.Now;
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

        var testInputs = MockedData.DateStrings;
        StringBuilder sb = new();

        DateTimeUtilities dateTimeUtilities = new DateTimeUtilities();
        foreach (var input in testInputs)
        {
            sb.AppendLine(DateTimeUtilities.GetDateFormat(input));
        }

        ResultsTextBox.Text = sb.ToString();
        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();

    }

    /// <summary>
    /// Converts a predefined <see cref="DateTime"/> value to Eastern Standard Time (EST)
    /// and displays the result in the <see cref="ResultsTextBox"/>.
    ///
    /// https://learn.microsoft.com/en-us/dotnet/standard/datetime/converting-between-time-zones
    /// 
    /// </summary>
    /// <remarks>
    /// If the Eastern Standard Time zone is not found or its data is corrupted,
    /// an appropriate error message is displayed in the <see cref="ResultsTextBox"/>.
    /// </remarks>
    private void ConvertToEasternButton_Click(object sender, EventArgs e)
    {
        DateTime easternTime = new DateTime(2026, 04, 02, 12, 16, 00);
        string easternZoneId = "Eastern Standard Time";
        try
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);
            ResultsTextBox.Text = $"The date and time are {TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone)} UTC.";
        }
        catch (TimeZoneNotFoundException)
        {
            ResultsTextBox.Text = $"Unable to find the {easternZoneId} zone in the registry.";
        }
        catch (InvalidTimeZoneException)
        {
            ResultsTextBox.Text = $"Registry data on the {easternZoneId} zone has been corrupted.";
        }

        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();

    }

    /// <summary>
    /// This method determines which radio button is selected within the <c>ExamplesGroupBox</c> 
    /// and displays the corresponding example result in the <c>ResultsTextBox</c>. 
    /// If no radio button is selected, it prompts the user to select an operator.
    /// </summary>
    private void OperatorsButton_Click(object sender, EventArgs e)
    {
        var selected = ExamplesGroupBox.RadioButtonChecked();
        if (selected is null)
        {
            ResultsTextBox.Text = "Please select an operator to see the example.";
            ResultsTextBox.Focus();
            ResultsTextBox.DeselectAll();
            return;
        }

        /*
         * switch against the Name property of the selected radio button
         * to determine which example to display in the ResultsTextBox.
         */
        ResultsTextBox.Text = selected.Name switch
        {
            nameof(EqualityRadioButton) => Examples.DateEquality(),
            nameof(GreaterThanRadioButton) => Examples.DateGreaterThan(),
            nameof(LessThanOrEqualRadioButton) => Examples.DateLessThanOrEqual(),
            nameof(AddSubtractRadioButton) => Examples.DateAddSubtract(),
            nameof(FormatDatesRadioButton) => Examples.FormatDateTimeExamples(),
            _ => ""
        };

        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();
        
    }
}

