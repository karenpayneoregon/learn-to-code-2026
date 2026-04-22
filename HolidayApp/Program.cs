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
        DisplayHolidaySchedule();

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }

    private static void DisplayHolidaySchedule()
    {
        
        SpectreConsoleHelpers.PrintPink();
        
        var list = GenerateHolidayTable();
        
        foreach (var item in list)
        {
            AnsiConsole.MarkupLine($"[HotPink]{item.Name, -30}[/]{item.Date:MM/dd/yyyy}");
            var tempDate = item.Date.AddDays(-3);
            Console.WriteLine($" {tempDate:MM/dd/yyyy} -> {tempDate.AddWorkingDays(5):MM/dd/yyyy}");
        }
    }

    /// <summary>
    /// Generates a list of holidays for the year 2026 in the United States.
    /// </summary>
    /// <param name="showTable">
    /// A boolean value indicating whether to display the holiday table in the console.
    /// If <c>true</c>, the table is displayed; otherwise, it is not.
    /// </param>
    /// <returns>
    /// A list of <see cref="HolidayItem"/> objects, each representing a holiday with its name and date.
    /// </returns>
    /// <remarks>
    /// This method retrieves holiday data using the <see cref="ExportHolidayFormatLocator"/> and processes it
    /// to create a list of holidays. Optionally, it can display the holidays in a formatted table using the
    /// Spectre.Console library. The resulting list is serialized to a JSON file named "holidays.json" if it
    /// does not already exist.
    /// </remarks>
    private static List<HolidayItem> GenerateHolidayTable(bool showTable = false)
    {

        if (showTable)
        {
            SpectreConsoleHelpers.PrintPink();
        }
        
        List<HolidayItem> holidays = [];

        var exporter = ExportHolidayFormatLocator.LocateByType(ExportType.OfficeHolidays);
        using var textWriter = new StringWriter();
        exporter.Export(new WorkingDayCultureInfo("en-US"), DateTime.Now.Year, textWriter);

        List<string> data = textWriter
            .ToString()
            .Split(Environment.NewLine)
            .Where(line => !string.IsNullOrWhiteSpace(line)) // last line may be empty
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

        if (showTable)
        {
            AnsiConsole.Write(table);
        }

        List<HolidayItem> ordered = holidays.OrderBy(x => x.Date).ToList();

        var json = System.Text.Json.JsonSerializer.Serialize(ordered, Indented);
        
        var fileName = "holidays.json";

        if (!File.Exists(fileName))
        {
            File.WriteAllText(fileName, json);
        }
        
        return ordered;
    }

    /// <summary>
    /// Demonstrates the usage of various date and time extension methods.
    /// </summary>
    private static void StockSamples()
    {

        SpectreConsoleHelpers.PrintPink();
        
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
