using ReleaseServiceApp.Classes;
using ReleaseServiceApp.Classes.Core;
using Spectre.Console;
using System.Reflection;

namespace ReleaseServiceApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        var releases = await DotNetReleaseService.GetReleaseIndexAsync();

        SpectreConsoleHelpers.InfoPill(Justify.Left, $"Found {releases.Count} releases.");
        Console.WriteLine();
        
        var table = new Table().Title("[bold blue] .NET Release Information [/]");
        table.AddColumn(new TableColumn("[bold yellow]Channel[/]"));
        table.AddColumn(new TableColumn("[bold yellow]Latest[/]"));
        table.AddColumn(new TableColumn("[bold yellow]ReleaseType[/]"));
        table.AddColumn(new TableColumn("[bold yellow]End Of Life Date[/]"));
        table.AddColumn(new TableColumn("[bold yellow]Support[/]"));

        foreach (var item in releases)
        {
            
            var eolText = item.EndOfLifeDate.HasValue
                ? item.EndOfLifeDate.Value.ToString("MM/dd/yyyy")
                : "Not set";
            
            var releaseType = item.ReleaseType ?? "Unknown";
            if (releaseType != "Unknown")
            {
                releaseType = releaseType.ToUpper();
            }

            table.AddRow(
                FrameworkUtilities.IsProjectFramework(item.ChannelVersion ?? ""), 
                item.LatestRelease ?? "",
                releaseType,
                eolText,
                Colorize(item.SupportPhase ?? "Unknown"));
        }

        AnsiConsole.Write(table);
        Console.WriteLine();

        var (found, isActive) = await FrameworkUtilities.ProjectFrameworkActive();
        if (found)
        {
            Console.WriteLine($"Project framework is {(isActive ? "active" : "not active")}.");
        }
        else
        {
            Console.WriteLine("Project framework not found.");
        }

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }

    /// <summary>
    /// Applies <a href="https://spectreconsole.net/console/reference/color-reference">color formatting</a> to the specified input string based on its content.
    /// </summary>
    /// <param name="input">The input string to be colorized.</param>
    /// <returns>
    /// 
    /// <para>
    ///    A colorized string formatted for <a href="https://spectreconsole.net/console">Spectre.Console</a>, based on the content of the input (case-insensitive):
    /// </para>
    /// 
    /// <list type="bullet">
    ///    <item>Returns a green-colored string if the input contains "active".</item>
    ///    <item>Returns a red-colored string if the input contains "eol".</item>
    ///    <item>Returns a yellow-colored string if the input contains "preview".</item>
    ///    <item>Returns the original input string if no match is found.</item>
    /// </list>
    /// </returns>
    private static string Colorize(string input) =>
        input switch
        {
            { } s when s.Contains("active", StringComparison.OrdinalIgnoreCase) => "[green]Active[/]",
            { } s when s.Contains("eol", StringComparison.OrdinalIgnoreCase) => "[red]eol[/]",
            { } s when s.Contains("preview", StringComparison.OrdinalIgnoreCase) => "[yellow]preview[/]",
            _ => input,
        };



}
