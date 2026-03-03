using KellermanSoftware.CompareNetObjects;

namespace TestProject1.Classes;
public static class StringExtensions
{
    /// <summary>
    /// Determines whether the <see cref="ComparisonResult"/> contains any differences.
    /// </summary>
    /// <param name="sender">The <see cref="ComparisonResult"/> instance to check for differences.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="ComparisonResult"/> contains differences; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasDifferences(this ComparisonResult sender) 
        => !sender.Differences.Any();
}
