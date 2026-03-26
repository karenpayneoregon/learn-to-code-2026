using CommonHelpersLibrary.Classes;
using Spectre.Console;
using WeekendApp.Classes.Core;

namespace WeekendApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        SpectreConsoleHelpers.PinkPill(Justify.Left, "Hello world");
        var dates = DateHelper.GetWeekendDates(DateTime.Now.Year, DateTime.Now.Month);
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
