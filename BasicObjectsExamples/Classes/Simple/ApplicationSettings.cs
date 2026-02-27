using System.Diagnostics;

namespace BasicObjectsExamples.Classes.Simple;

/// <summary>
/// Represents application-wide settings, implemented as a thread-safe singleton.
/// This class provides centralized access to configuration values such as folder and file names.
/// </summary>
/// <remarks>
/// When you apply the sealed modifier to a class,
/// it prevents other classes from inheriting from that class.
/// </remarks>
public sealed class ApplicationSettings
{
    private static readonly Lazy<ApplicationSettings> Lazy = new(() => 
        new ApplicationSettings());

    public static ApplicationSettings Instance => Lazy.Value;
    
    public string FolderName { get; set; }
    public string FileName { get; set; }

    /// <summary>
    /// Constructor is private to prevent direct instantiation.
    /// The singleton instance is accessed via the static Instance property.
    /// </summary>
    /// <remarks>
    /// Settings may be loaded from a configuration file or a database in a real application.
    /// </remarks>
    private ApplicationSettings()
    {
        FolderName = "C:\\Files";
        FileName = "data.xlsx";

        /*
         * Will get hit the first time the Instance property is accessed,
         */
        //Debugger.Break(); 
    }
}