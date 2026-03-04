#nullable disable
using TeamSettingsLibrary.Models;

namespace TeamSettingsLibrary.Classes;

/// <summary>
/// Provides helper methods to retrieve configuration settings from the application's
/// JSON configuration file.
/// </summary>
/// <remarks>
/// This class is designed to simplify access to specific configuration values,
/// such as server name and catalog, by leveraging the application's configuration structure.
///
/// [Config] is an alias in the project file to a NuGet package that provides a
/// static class for accessing configuration settings.
/// </remarks>
public class ConfigurationRootHelper
{
    public static string ServerName() =>
        Config.Configuration.JsonRoot()
            .GetSection(nameof(ApplicationSettings))[nameof(ApplicationSettings.Server)];
    public static string Catalog() =>
        Config.Configuration.JsonRoot()
            .GetSection(nameof(ApplicationSettings))[nameof(ApplicationSettings.Catalog)];
}