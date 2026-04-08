namespace WorkingWithDatesAndTime.Classes;

public static class BoolExtensions
{
    /// <summary>
    /// Converts a <see cref="bool"/> value to its corresponding "Yes" or "No" string representation.
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <returns>
    /// A string "Yes" if <paramref name="value"/> is <c>true</c>, or "No" if <paramref name="value"/> is <c>false</c>.
    /// </returns>
    /// <example>
    /// <code>
    /// bool isActive = true;
    /// string result = isActive.ToYesNo(); // result will be "Yes"
    /// </code>
    /// </example>
    public static string ToYesNo(this bool value) 
        => value ? "Yes" : "No";
}
