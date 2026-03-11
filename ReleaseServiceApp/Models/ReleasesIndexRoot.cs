using System.Text.Json.Serialization;

namespace ReleaseServiceApp.Models;

/// <summary>
/// Represents the root object for the .NET releases index.
/// </summary>
/// <remarks>
/// This class is used to deserialize the JSON structure containing the release index metadata.
/// It contains a collection of <see cref="ReleaseServiceApp.Models.ReleaseIndexItem"/> objects
/// that provide detailed information about each release channel.
/// </remarks>
public sealed class ReleasesIndexRoot
{
    [JsonPropertyName("releases-index")]
    public List<ReleaseIndexItem>? ReleasesIndex { get; set; }
}