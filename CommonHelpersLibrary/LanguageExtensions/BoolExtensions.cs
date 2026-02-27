namespace CommonHelpersLibrary.LanguageExtensions;

/// <summary>
/// Provides extension methods for the <see cref="bool"/> type.
/// </summary>
public static class BoolExtensions
{
    /// <summary>
    /// Converts a <see cref="bool"/> value to its corresponding "Yes" or "No" string representation.
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <returns>
    /// Returns "Yes" if <paramref name="value"/> is <c>true</c>; otherwise, returns "No".
    /// </returns>
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
}