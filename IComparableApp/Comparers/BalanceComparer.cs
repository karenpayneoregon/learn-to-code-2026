using IComparableApp.Models;

namespace IComparableApp.Comparers;

/// <summary>
/// Provides a comparison mechanism for <see cref="BankAccount"/> objects based on their <see cref="BankAccount.Balance"/> values.
/// </summary>
/// <remarks>
/// This comparer is used to compare two <see cref="BankAccount"/> instances by their <see cref="BankAccount.Balance"/> in ascending order.
/// If either of the compared objects is <c>null</c>, the comparison handles <c>null</c> values appropriately:
/// <list type="bullet">
/// <item>
/// <description>If both objects are <c>null</c>, they are considered equal.</description>
/// </item>
/// <item>
/// <description>If only one object is <c>null</c>, the <c>null</c> object is considered less than the non-<c>null</c> object.</description>
/// </item>
/// </list>
/// </remarks>
public class BalanceComparer : IComparer<BankAccount>
{
    public int Compare(BankAccount? x, BankAccount? y)
    {
        return x switch
        {
            null when y is null => 0,
            null => -1,
            _ => y is null ? 1 : x.Balance.CompareTo(y.Balance)
        };
    }
}