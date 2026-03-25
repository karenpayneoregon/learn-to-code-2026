using IComparableApp.Models;

namespace IComparableApp.Comparers;

/// <summary>
/// Provides a comparison mechanism for <see cref="BankAccount"/> objects based on their <see cref="BankAccount.Name"/> property.
/// </summary>
/// <remarks>
/// This comparer performs a case-sensitive, ordinal string comparison of the <see cref="BankAccount.Name"/> property.
/// </remarks>
public class NameComparer : IComparer<BankAccount>
{
    public int Compare(BankAccount? x, BankAccount? y)
    {
        return string.Compare(x?.Name, y?.Name, StringComparison.Ordinal);
    }
}