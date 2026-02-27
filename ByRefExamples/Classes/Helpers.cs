
using System.Text.RegularExpressions;

namespace ByRefExamples.Classes;

/// <summary>
/// Provides helper methods for manipulating strings, particularly those containing numeric portions.
/// </summary>
/// <remarks>
/// This class includes methods for incrementing numeric portions of strings, either by value or by reference.
/// It is designed to handle scenarios where strings have numeric suffixes that need to be updated programmatically.
/// </remarks>
public partial class Helpers
{

    /// <summary>
    /// Generates the next value in a sequence by incrementing the numeric portion of the input string.
    /// </summary>
    /// <param name="sender">
    /// The input string containing a numeric portion at the end. The numeric portion will be incremented.
    /// </param>
    /// <param name="incrementBy">
    /// The value by which to increment the numeric portion of the input string. Defaults to 1.
    /// </param>
    /// <returns>
    /// A new string with the numeric portion incremented by the specified value, preserving the original length of the numeric portion.
    /// </returns>
    /// <exception cref="System.FormatException">
    /// Thrown if the numeric portion of the input string cannot be parsed as a valid number.
    /// </exception>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown if the <paramref name="sender"/> is <c>null</c>.
    /// </exception>
    public static string NextValue(string sender, int incrementBy = 1)
    {
        string value = NumbersPattern().Match(sender).Value;

        return sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }

    /// <summary>
    /// Updates the input string by incrementing the numeric portion at the end of the string.
    /// </summary>
    /// <param name="sender">
    /// A reference to the input string containing a numeric portion at the end. 
    /// The numeric portion will be incremented, and the updated string will be assigned back to this parameter.
    /// </param>
    /// <param name="incrementBy">
    /// The value by which to increment the numeric portion of the input string. Defaults to 1.
    /// </param>
    /// <exception cref="System.FormatException">
    /// Thrown if the numeric portion of the input string cannot be parsed as a valid number.
    /// </exception>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown if the <paramref name="sender"/> is <c>null</c>.
    /// </exception>
    public static void NextValue(ref string sender, int incrementBy = 1)
    {
        string value = NumbersPattern().Match(sender).Value;

        sender = sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }
    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPattern();
}

