using System.Reflection;
using System.Runtime.Versioning;

namespace ReleaseServiceApp.Classes.Core;

public static class FrameworkUtilities
{
    /// <summary>
    /// Retrieves the target framework version of the specified assembly.
    /// </summary>
    /// <param name="assembly">
    /// The <see cref="Assembly"/> instance from which to retrieve the target framework version.
    /// </param>
    /// <returns>
    /// A <see cref="Version"/> representing the target framework version if available; otherwise, <c>null</c>.
    /// </returns>
    /// <remarks>
    /// This method attempts to extract the framework version from the <see cref="System.Runtime.Versioning.TargetFrameworkAttribute"/> 
    /// applied to the assembly. If the framework version cannot be determined, it returns <c>null</c>.
    /// </remarks>
    public static Version? GetTargetFrameworkVersion(this Assembly assembly)
    {
        
        var framework = assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

        if (string.IsNullOrWhiteSpace(framework))
            return null;

        // Common format: ".NETCoreApp,Version=v9.0"
        const string marker = "Version=v";
        var id = framework.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
        if (id >= 0)
        {
            var versionText = framework[(id + marker.Length)..].Trim();
            var comma = versionText.IndexOf(',');
            if (comma >= 0) versionText = versionText[..comma];

            return Version.TryParse(versionText, out var v) ? v : null;
        }

        // Alternate format some devs may see: ".NET 9.0"
        var lastSpace = framework.LastIndexOf(' ');
        if (lastSpace < 0 || lastSpace + 1 >= framework.Length) return Version.TryParse(framework, out var direct) ? direct : null;
        {
            var versionText = framework[(lastSpace + 1)..].Trim();
            return Version.TryParse(versionText, out var v) ? v : null;
        }

    }

    /// <summary>
    /// Determines whether the specified framework version matches the current project's framework version.
    /// </summary>
    /// <param name="sender">
    /// A <see cref="string"/> representing the framework version to compare against the current project's framework version.
    /// </param>
    /// <returns>
    /// A <see cref="string"/> indicating the comparison result. If the specified framework matches the current project's framework,
    /// the result includes a check mark symbol (:check_mark:). Otherwise, it returns the original framework version string.
    /// </returns>
    /// <remarks>
    /// This method retrieves the current project's framework version using the entry assembly's target framework attribute
    /// and compares it with the provided framework version string.
    /// </remarks>
    public static string IsProjectFramework(string sender)
    {
        if (string.IsNullOrWhiteSpace(sender))
        {
            return sender;
        }

        var frameworkVersion = FrameworkVersion();
        var currentFramework = frameworkVersion?.ToString();
        
        return string.Equals(sender, currentFramework, StringComparison.OrdinalIgnoreCase)
            ? $"{sender} :check_mark:"
            : $"{sender}";
    }

    /// <summary>
    /// Determines whether the current project's framework is active and supported.
    /// </summary>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The result is a tuple containing:
    /// <list type="bullet">
    /// <item>
    /// <description><c>found</c>: A <see cref="bool"/> indicating whether the current framework was found in the release index.</description>
    /// </item>
    /// <item>
    /// <description><c>isActive</c>: A <see cref="bool"/> indicating whether the current framework is in an active support phase.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// This method retrieves the entry assembly's target framework version and compares it against the .NET release index.
    /// If the framework version is found, it checks whether the framework is in the "active" support phase.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    /// Thrown if the entry assembly cannot be determined.
    /// </exception>
    public static async Task<(bool found, bool isActive)> ProjectFrameworkActive()
    {
        var frameworkVersion = FrameworkVersion();
        var currentFramework = frameworkVersion?.ToString();
        
        var current = (await DotNetReleaseService.GetReleaseIndexAsync()).FirstOrDefault(x => x.ChannelVersion == currentFramework);
        if (current is not null)
        {
           return (true, current.SupportPhase.Contains("active", StringComparison.OrdinalIgnoreCase));
        }
        else
        {
            return (false, false);
        }
    }

    /// <summary>
    /// Retrieves the target framework version of the entry assembly.
    /// </summary>
    /// <returns>
    /// A <see cref="System.Version"/> representing the target framework version of the entry assembly if available; otherwise, <c>null</c>.
    /// </returns>
    /// <remarks>
    /// This method utilizes the <see cref="GetTargetFrameworkVersion"/> extension method to extract the framework version
    /// from the entry assembly's <see cref="System.Runtime.Versioning.TargetFrameworkAttribute"/>.
    /// If the entry assembly is unavailable or the framework version cannot be determined, it returns <c>null</c>.
    /// </remarks>
    private static Version? FrameworkVersion()
    {
        Assembly? entryAssembly = Assembly.GetEntryAssembly();
        Version? frameworkVersion = entryAssembly?.GetTargetFrameworkVersion();
        return frameworkVersion;
    }
}