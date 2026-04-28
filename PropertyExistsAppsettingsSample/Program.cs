using ConsoleConfigurationLibrary.Classes;
using PropertyExistsAppsettingsSample.Classes.Configuration;
using PropertyExistsAppsettingsSample.Classes.Core;
using Spectre.Console;

namespace PropertyExistsAppsettingsSample;
internal partial class Program
{
    static void Main(string[] args)
    {
        SpectreConsoleHelpers.PinkPill(Justify.Left, "Property exists check");
        
        if (JsonHelpers.MainConnectionExists())
        {
            SpectreConsoleHelpers.PinkPill(Justify.Left, AppConnections.Instance.MainConnection);
        }
        else
        {
            SpectreConsoleHelpers.ErrorPill(Justify.Left, "MainConnection does not exist");
        }

        Console.WriteLine();
        
        if (JsonHelpers.PropertyExists("About","Text"))
        {
            SpectreConsoleHelpers.PinkPill(Justify.Left, "About.Text exists");
        }
        else
        {
            SpectreConsoleHelpers.ErrorPill(Justify.Left, "About.Text does not exist");
        }

        Console.WriteLine();

        if (JsonHelpers.PropertyExists("Logs", "SomeSetting"))
        {
            SpectreConsoleHelpers.PinkPill(Justify.Left, "Logs.SomeSetting exists");
        }
        else
        {
            SpectreConsoleHelpers.ErrorPill(Justify.Left, "Logs.SomeSetting does not exist");
        }

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
        
    }
}
