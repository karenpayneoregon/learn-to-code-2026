namespace IComparableApp.Models;

/// <summary>
/// Represents a bank account with a name and balance, and provides functionality to compare instances.
/// </summary>
/// <remarks>
/// Instances of <see cref="BankAccount"/> can be compared using the <see cref="IComparable{T}"/> interface.
/// The comparison is primarily based on the <see cref="Balance"/> property in ascending order. If balances are equal,
/// the comparison falls back to the <see cref="Name"/> property in lexicographical order.
/// </remarks>
public class BankAccount : IComparable<BankAccount>
{
    public required string Name { get; set; }
    public decimal Balance { get; set; }

    /// <summary>
    /// Compares the current <see cref="BankAccount"/> instance with another <see cref="BankAccount"/> object
    /// and returns an integer that indicates their relative order.
    /// </summary>
    /// <param name="other">The <see cref="BankAccount"/> to compare with the current instance.</param>
    /// <returns>
    /// A value that indicates the relative order of the objects being compared:
    /// <list type="bullet">
    /// <item>
    /// <description>A negative integer if this instance precedes <paramref name="other"/> in the sort order.</description>
    /// </item>
    /// <item>
    /// <description>Zero if this instance occurs in the same position as <paramref name="other"/> in the sort order.</description>
    /// </item>
    /// <item>
    /// <description>A positive integer if this instance follows <paramref name="other"/> in the sort order.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// The comparison is performed first by <see cref="Balance"/> in ascending order. If the balances are equal,
    /// the comparison falls back to comparing <see cref="Name"/> in lexicographical order.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="other"/> is <c>null</c>.</exception>
    public int CompareTo(BankAccount? other)
    {
        if (other is null) return 1;

        int balanceComparison = Balance.CompareTo(other.Balance);

        return balanceComparison != 0 ?
            balanceComparison
            : string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}