
## Copilot recommendation

- The key `StringComparison.OrdinalIgnoreCase` can be used to perform case-insensitive string comparisons.
- For non-Framcis code avoid single character variable names, as they can be confusing. Use descriptive variable names instead.

```csharp
// C#
foreach (string[] transaction in records)
{
    // normalize items (trim) so whitespace won't break matching
    for (int i = 0; i < transaction.Length; i++)
        transaction[i] = transaction[i].Trim();

    balance += transaction switch
    {
        [_, var t, _, var amount] when string.Equals(t, "DEPOSIT", StringComparison.OrdinalIgnoreCase)
            => GetDecimal(amount),

        [_, var t, .., var amount] when string.Equals(t, "WITHDRAWAL", StringComparison.OrdinalIgnoreCase)
            => -GetDecimal(amount),

        [_, var t, var amount] when string.Equals(t, "INTEREST", StringComparison.OrdinalIgnoreCase)
            => GetDecimal(amount),

        [_, var t, .., var fee] when string.Equals(t, "FEE", StringComparison.OrdinalIgnoreCase)
            => -GetDecimal(fee),

        _ => throw new InvalidOperationException(
            $"Record {string.Join(", ", transaction)} is invalid"),
    };

    // ...
}
```