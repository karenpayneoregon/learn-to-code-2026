using DateTimeExtensions;
using DateTimeExtensions.Export;
using DateTimeExtensions.TimeOfDay;
using DateTimeExtensions.WorkingDays;
using HolidayApp.Classes.Core;
using Spectre.Console;
using System.IO;
using HolidayApp.Models;

namespace HolidayApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }

    /// <summary>
    /// Generates and displays a table of holidays for the year 2026 in the United States.
    /// </summary>
    /// <remarks>
    /// This method uses the <see cref="ExportHolidayFormatLocator"/> to export holiday data
    /// in the "OfficeHolidays" format for the "en-US" culture. The data is then processed
    /// and displayed in a formatted table using the Spectre.Console library.
    /// </remarks>
    private static List<HolidayItem> GenerateHolidayTable()
    {
        List<HolidayItem> holidays = [];
        
        var exporter = ExportHolidayFormatLocator.LocateByType(ExportType.OfficeHolidays);
        using var textWriter = new StringWriter();
        exporter.Export(new WorkingDayCultureInfo("en-US"), 2026, textWriter);
        
        List<string> data = textWriter
            .ToString()
            .Split(Environment.NewLine)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Skip(1) // Skip the header line
            .ToList();
        

        var table = new Table()
            .BorderColor(Color.Blue)
            .Title("[yellow]US Holidays 2026[/]")
            .AddColumn(new TableColumn("[bold yellow]Holiday[/]"))
            .AddColumn(new TableColumn("[bold yellow]Date[/]"));

        foreach (var line in data)
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                DateTime date = DateTime.Parse(parts[1].Trim());
                table.AddRow(parts[0].Trim(), date.ToString("MM/dd/yyyy"));
                holidays.Add(new HolidayItem() { Name = parts[0].Trim(), Date = date });
            }
        }

        AnsiConsole.Write(table);
        
        return holidays;
    }

    /// <summary>
    /// Demonstrates the usage of various date and time extension methods.
    /// </summary>
    private static void StockSamples()
    {
        // Add 5 working days to a date
        DateTime futureDate = DateTime.Now.AddWorkingDays(5);

        // Check if a date is a working day
        bool isWorkingDay = DateTime.Now.IsWorkingDay();

        // Get the difference between dates in natural language
        string dateDiff = DateTime.Now.ToNaturalText(DateTime.Now.AddDays(45));

        // Check if a time is between two other times
        bool isBetween = DateTime.Now.IsBetween(new Time(9), new Time(17));
    }
}
