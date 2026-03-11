using System.Text.Json.Serialization;

namespace ReleaseServiceApp.Models;

/// <summary>
/// Represents an individual item in the .NET releases index.
/// </summary>
/// <remarks>
/// This class is used to deserialize the JSON structure for a single release channel.
/// It contains metadata such as the channel version, latest release details, support phase, 
/// and URLs for additional release information.
/// </remarks>
public sealed class ReleaseIndexItem
{
    [JsonPropertyName("channel-version")]
    public string? ChannelVersion { get; set; }

    [JsonPropertyName("latest-release")]
    public string? LatestRelease { get; set; }

    [JsonPropertyName("latest-release-date")]
    public DateTime? LatestReleaseDate { get; set; }

    [JsonPropertyName("security")]
    public bool Security { get; set; }

    [JsonPropertyName("latest-runtime")]
    public string? LatestRuntime { get; set; }

    [JsonPropertyName("latest-sdk")]
    public string? LatestSdk { get; set; }

    [JsonPropertyName("product")]
    public string? Product { get; set; }

    /// <summary>
    /// Gets or sets the support phase of the release.
    /// </summary>
    /// <remarks>
    /// The support phase indicates the current lifecycle stage of the release, 
    /// such as "active", "preview", or "eol" (end of life).
    /// </remarks>
    [JsonPropertyName("support-phase")]
    public string? SupportPhase { get; set; }

    [JsonPropertyName("eol-date")]
    public DateTime? EndOfLifeDate { get; set; }

    [JsonPropertyName("release-type")]
    public string? ReleaseType { get; set; }

    [JsonPropertyName("releases.json")]
    public string? ReleasesJsonUrl { get; set; }
}