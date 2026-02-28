namespace IComparerIEqualityComparerApp.Classes.LanguageExtensions;
public static class StringExtensions
{
    /// <summary>
    /// Capitalizes the first letter of the specified string.
    /// </summary>
    /// <param name="input">The input string to process. Can be <c>null</c> or empty.</param>
    /// <returns>
    /// A new string with the first letter capitalized if the input is not <c>null</c> or whitespace; 
    /// otherwise, returns the original input.
    /// </returns>
    public static string? CapitalizeFirstLetter(this string? input)
        => string.IsNullOrWhiteSpace(input) ?
            input : char.ToUpper(input[0]) + input.AsSpan(1).ToString();
}
