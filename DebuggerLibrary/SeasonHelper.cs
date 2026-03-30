
using DebuggerLibrary.Models;
using Spectre.Console;

namespace DebuggerLibrary;

public class SeasonHelper
{
    /// <summary>
    /// Gets the predefined color corresponding to the current season.
    /// </summary>
    private static readonly Dictionary<Season, Color> SeasonColors = new()
    {
        { Season.Winter, Color.Blue },
        { Season.Spring, Color.LightGreen },
        { Season.Summer, Color.Yellow },
        { Season.Autumn, Color.Orange1 }
    };

    public static Color GetSeasonColor()
    {
        var season = GetCurrentSeason();
        return SeasonColors.TryGetValue(season, out var color) ? color : Color.Grey; ;
    }

    /// <summary>
    /// Retrieves the name of the color associated with the current season.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> representing the name of the color for the current season.
    /// </returns>
    /// <remarks>
    /// Main use is for Spectre.Console color markup.
    /// </remarks>
    public static string GetSeasonColorName()
        => GetSeasonColor().ToString();

    /// <summary>
    /// Determines the current season based on the current month.
    /// </summary>
    /// <returns>
    /// A <see cref="Season"/> value representing the current season.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the current month does not fall within the expected range of 1 to 12.
    /// </exception>
    public static Season GetCurrentSeason() =>
        DateTime.Now.Month switch
        {
            12 or 1 or 2 => Season.Winter,
            3 or 4 or 5 => Season.Spring,
            6 or 7 or 8 => Season.Summer,
            9 or 10 or 11 => Season.Autumn,
            _ => throw new ArgumentOutOfRangeException()
        };
}
