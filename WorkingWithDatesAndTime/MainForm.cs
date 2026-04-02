
using WorkingWithDatesAndTime.Classes;
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
        var value = "04/09/2026 13:35"; // valid date string in MM/dd/yyyy format

        {
            if (DateTime.TryParse(value, out DateTime parsedDate))
            {
                Dialogs.Information(this,$"Parsed date: {parsedDate}");
            }
            else
            {
                Dialogs.Information(this, $"Failed to parse {value}.");
            }
        }

        value = "0409/2026 13:35"; // bad date time format

        {
            if (DateTime.TryParse(value, out DateTime parsedDate))
            {
                Dialogs.Information(this, $"Parsed date: {parsedDate}");
            }
            else
            {
                Dialogs.Information(this, $"Failed to parse {value}.");
            }
        }

    }

    private void GroupWorkDaysByWeekButton_Click(object sender, EventArgs e)
    {
        ReultsTextBox.Text = Examples.GroupWorkDaysByWeek();
        ReultsTextBox.Select(0, 0);
        ActiveControl = ReultsTextBox;
    }
}
