
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
        StringBuilder sb = new();

        var value = "04/09/2026 13:35"; // valid date string in MM/dd/yyyy format

        {
            if (DateTime.TryParse(value, out DateTime parsedDate))
            {
                sb.AppendLine($"Parsed date: {parsedDate}");
            }
            else
            {
                sb.AppendLine($"Failed to parse {value}.");
            }
        }

        value = "0409/2026 13:35"; // bad date time format

        sb.AppendLine();
        sb.AppendLine("--- Invalid format ---");
        sb.AppendLine();

        {
            if (DateTime.TryParse(value, out DateTime parsedDate))
            {
                sb.AppendLine($"Parsed date: {parsedDate}");
            }
            else
            {
                sb.AppendLine($"Failed to parse {value}.");
            }
        }

        sb.AppendLine();
        sb.AppendLine("--- Another example ---");
        sb.AppendLine();

        // Example with a valid date string in a different format
        value = "2026-09-04 13:35:00"; // valid date string in yyyy-MM-dd HH:mm:ss format

        if (DateTime.TryParse(value, out DateTime parsedDate2))
        {
            sb.AppendLine($"Parsed date: {parsedDate2}");
        }
        else
        {
            sb.AppendLine($"Failed to parse {value}.");
        }

        ResultsTextBox.Text = sb.ToString();

        ResultsTextBox.Focus();
        ResultsTextBox.DeselectAll();

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
}

