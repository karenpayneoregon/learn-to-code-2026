using Microsoft.Extensions.DependencyInjection;
using WorkingWithDatesAndTime.Classes.Configuration;

namespace WorkingWithDatesAndTime;
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        await Setup();
        Application.Run(new MainForm());
    }
    /// <summary>
    /// Setup for reading connection strings and entity settings from appsettings.json
    /// </summary>
    private static async Task Setup()
    {
        var services = Classes.Configuration.ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
        serviceProvider.GetService<SetupServices>()!.GetEntitySettings();


        CreateDailyLogDirectory();
    }

    /// <summary>
    /// Creates a directory for daily log files based on the current date.
    /// </summary>
    /// <remarks>
    /// The directory is created under the application's base directory in a folder named "LogFiles",
    /// with a subfolder named after the current date in "yyyy-MM-dd" format.
    /// If the directory already exists, no action is taken. Any exceptions during the creation process are ignored.
    /// </remarks>
    private static void CreateDailyLogDirectory()
    {
        string outDir = AppContext.BaseDirectory;

        string logDir = Path.Combine(
            outDir,
            "LogFiles",
            DateTime.Now.ToString("yyyy-MM-dd")
        );

        try
        {
            Directory.CreateDirectory(logDir);
        }
        catch (Exception)
        {
            // ignored
        }
    }
}