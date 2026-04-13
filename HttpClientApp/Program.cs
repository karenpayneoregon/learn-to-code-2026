using HttpClientApp.Classes.Core;
using Spectre.Console;
using System.Net.Http.Json;
using HttpClientApp.Classes;

namespace HttpClientApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        SpectreConsoleHelpers.PinkPill(Justify.Left, "HttpClient.GetFromJsonAsync");

        using HttpClient client = new()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
        };

        User? user = await client.GetFromJsonAsync<User>("users/1");

        Console.WriteLine();
        AnsiConsole.MarkupLine($"[cyan]Id:[/] {user?.Id}");
        AnsiConsole.MarkupLine($"[cyan]Name:[/] {user?.Name}");
        AnsiConsole.MarkupLine($"[cyan]Username:[/] {user?.Username}");
        AnsiConsole.MarkupLine($"[cyan]Email:[/] {user?.Email}");
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
