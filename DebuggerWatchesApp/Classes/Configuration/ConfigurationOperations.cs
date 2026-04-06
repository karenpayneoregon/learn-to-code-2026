using System.Text.Json;

namespace DebuggerWatchesApp.Classes.Configuration;

/// <summary>
/// Provides operations for reading and saving configuration.
/// </summary>
public class ConfigurationOperations
{
    private static string FileName 
        => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

    /// <summary>
    /// Reads the configuration from the appsettings.json file.
    /// </summary>
    /// <returns>The configuration object.</returns>
    public static Models.Configuration.Configuration ReadConfiguration()
    {
        var json = File.ReadAllText(FileName);
        
        return JsonSerializer.Deserialize<Models.Configuration.Configuration>(json)
               ?? throw new InvalidOperationException("Failed to deserialize configuration.");
        
    }

    /// <summary>
    /// Saves the configuration to the appsettings.json file.
    /// </summary>
    /// <param name="configuration">The configuration object to save.</param>
    public static void SaveChanges(Models.Configuration.Configuration configuration)
    {
        
        var json = JsonSerializer.Serialize(configuration, Indented);
        File.WriteAllText(FileName, json);
        
    }

    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}