#nullable disable

using Microsoft.Extensions.Configuration;

namespace ReadSettingsFromAppsettingsApp.Classes;
internal class ConfigurationRootHelper
{
    /// <summary>
    /// Builds and returns an <see cref="IConfigurationRoot"/> object by reading configuration settings
    /// from the appsettings.json file, environment variables, and the current directory.
    /// </summary>
    /// <returns>
    /// An <see cref="IConfigurationRoot"/> object containing the configuration settings.
    /// </returns>
    /// <remarks>
    /// The method uses the <see cref="ConfigurationBuilder"/> to load configuration data from:
    /// <list type="bullet">
    /// <item>The appsettings.json file (required).</item>
    /// </list>
    /// </remarks>
    public static IConfigurationRoot ConfigurationRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

    public static string ServerName() =>
        ConfigurationRoot().GetSection("ApplicationSettings")["Server"];
    public static string Catalog() =>
        ConfigurationRoot().GetSection("ApplicationSettings")["Catalog"];
}