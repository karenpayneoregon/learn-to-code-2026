using ReadSettingsFromAppsettingsApp.Classes;
using ReadSettingsFromAppsettingsApp.Classes.Core;
using Spectre.Console;

namespace ReadSettingsFromAppsettingsApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(ConfigurationRootHelper.ServerName());
        Console.WriteLine(ConfigurationRootHelper1.ServerName());
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
