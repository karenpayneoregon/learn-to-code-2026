using System.Text.Json;
using ReleaseServiceApp.Models;

namespace ReleaseServiceApp.Classes;

public static class DotNetReleaseService
{
    private static readonly HttpClient _httpClient = new();

    /// <summary>
    /// Retrieves the release index for .NET releases asynchronously.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests. Defaults to <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of 
    /// <see cref="ReleaseServiceApp.Models.ReleaseIndexItem"/> representing the release index.
    /// </returns>
    /// <remarks>
    /// This method fetches the release metadata from a predefined URL and deserializes it into a list of 
    /// <see cref="ReleaseServiceApp.Models.ReleaseIndexItem"/> objects. If the metadata cannot be retrieved 
    /// or deserialized, an empty list is returned.
    /// </remarks>
    /// <exception cref="HttpRequestException">
    /// Thrown when the HTTP request to fetch the release metadata fails.
    /// </exception>
    /// <exception cref="TaskCanceledException">
    /// Thrown when the operation is canceled via the provided <paramref name="cancellationToken"/>.
    /// </exception>
    public static async Task<List<ReleaseIndexItem>> GetReleaseIndexAsync(CancellationToken cancellationToken = default)
    {
        const string url = "https://dotnetcli.azureedge.net/dotnet/release-metadata/releases-index.json";

        using HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);


        var root = await JsonSerializer.DeserializeAsync<ReleasesIndexRoot>(
            stream,
            Options,
            cancellationToken);

        return root?.ReleasesIndex ?? [];
    }

    public static JsonSerializerOptions Options => new() { PropertyNameCaseInsensitive = true };
}