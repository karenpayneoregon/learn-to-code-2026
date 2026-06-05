using System.Numerics;

namespace InterfaceExamples.Classes;
public static class GenericExtensions
{
    /// <summary>Determines if a value represents an even integral value.</summary>
    public static bool IsEven<T>(this T sender) where T : INumber<T>
        => T.IsEvenInteger(sender);

    /// <summary>Determines if a value represents an odd integral value.</summary>
    public static bool IsOdd<T>(this T sender) where T : INumber<T>
        => T.IsOddInteger(sender);

    public static T Max<T>(this T sender, T other) where T : INumber<T>
        => T.Max(sender, other);

    /// <summary>
    /// Clamps a value to a specified range defined by a minimum and maximum value.
    /// </summary>
    /// <typeparam name="T">
    /// The numeric type of the value, minimum, and maximum. Must implement <see cref="System.Numerics.INumber{T}"/>.
    /// </typeparam>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The inclusive minimum value of the range.</param>
    /// <param name="max">The inclusive maximum value of the range.</param>
    /// <returns>
    /// The clamped value, which will be equal to <paramref name="min"/> if <paramref name="value"/> is less than <paramref name="min"/>, 
    /// or <paramref name="max"/> if <paramref name="value"/> is greater than <paramref name="max"/>. 
    /// Otherwise, it will return <paramref name="value"/>.
    /// </returns>
    public static T Clamp<T>(this T value, T min, T max) where T : INumber<T>
        => T.Clamp(value, min, max);
    
}