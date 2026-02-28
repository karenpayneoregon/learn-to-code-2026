using System.Text;
using System.Text.RegularExpressions;

namespace CommonHelpersLibrary.LanguageExtensions;
public static partial class StringExtensions
{

    /// <summary>
    /// Compares two strings for equality, ignoring case differences.
    /// </summary>
    /// <param name="source">The first string to compare. Can be <c>null</c>.</param>
    /// <param name="target">The second string to compare. Can be <c>null</c>.</param>
    /// <returns>
    /// <c>true</c> if both strings are equal ignoring case, or if both are <c>null</c>;
    /// otherwise, <c>false</c>.
    /// </returns>
    public static bool EqualsIgnoreCase(this string source, string target)
    {
        
        if (source == null && target == null)
        {
            return true;
        }
        
        if (source == null || target == null)
        {
            return false;
        }

        return source.Equals(target, StringComparison.OrdinalIgnoreCase);
        
    }

    /// <summary>
    /// Determines whether the specified <paramref name="value"/> occurs within the <paramref name="source"/> string, 
    /// using a case-insensitive comparison.
    /// </summary>
    /// <param name="source">The string to search. Can be <c>null</c>.</param>
    /// <param name="value">The string to locate within <paramref name="source"/>. Can be <c>null</c>.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="value"/> is found within <paramref name="source"/> ignoring case; 
    /// otherwise, <c>false</c>. Returns <c>false</c> if <paramref name="source"/> is <c>null</c>.
    /// </returns>
    public static bool ContainsIgnoreCase(this string source, string value)
    {
        // Handle null cases for robustness
        if (source == null) return false; // A null string cannot contain anything
        if (value == null) return true; // A string can be considered to contain a null or empty string

        return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
    }
    /// <summary>
    /// Joins the elements of the specified <paramref name="source"/> collection into a single string, 
    /// using the specified <paramref name="separator"/> between most elements and the specified 
    /// <paramref name="token"/> before the last element.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the <paramref name="source"/> collection.</typeparam>
    /// <param name="source">The collection of elements to join. If <c>null</c>, an empty string is returned.</param>
    /// <param name="separator">
    /// The string to use as a separator between elements, except for the last element. 
    /// Defaults to <c>", "</c> if not specified.
    /// </param>
    /// <param name="token">
    /// The string to use before the last element in the joined result. 
    /// Defaults to <c>"and"</c> if not specified.
    /// </param>
    /// <returns>
    /// A string that consists of the elements in <paramref name="source"/> joined by the specified 
    /// <paramref name="separator"/> and <paramref name="token"/>. Returns an empty string if 
    /// <paramref name="source"/> is empty or <c>null</c>.
    /// </returns>
    public static string JoinWithLastSeparator<T>(this IEnumerable<T> source, string separator = ", ", string token = "and")
    {
        if (source is null) return string.Empty;
        
        separator ??= ", ";
        token ??= "and";

        using var ge = source.GetEnumerator();
        if (!ge.MoveNext()) return string.Empty;

        var first = ge.Current?.ToString() ?? string.Empty;
        if (!ge.MoveNext()) return first;

        StringBuilder sb = new(first);
        var prev = ge.Current?.ToString() ?? string.Empty;

        while (ge.MoveNext())
        {
            sb.Append(separator);
            sb.Append(prev);
            prev = ge.Current?.ToString() ?? string.Empty;
        }

        sb.Append(' ')
            .Append(token)
            .Append(' ')
            .Append(prev);
        
        return sb.ToString();
    }

    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseRegex.Matches(sender)
            .Select(m => m.Value));

    /// <summary>
    /// Regular expression pattern for matching camel case words.
    /// </summary>
    private static readonly Regex CamelCaseRegex = CasingRegex();
    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CasingRegex();
}
