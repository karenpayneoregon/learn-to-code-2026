using JsonCommentsSample.Classes.Core;
using Microsoft.Extensions.Options;
using Spectre.Console;
using System.Text.Json;
using HttpClientApp.Classes;

namespace JsonCommentsSample;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Json with comments[/]");
        var person = new Person
        {
            FirstName = "Jack",
            LastName = "Smith",
            BirthDate = new DateOnly(2000, 1, 1)
        };

        var json = JsonSerializer.Serialize(person, Options);
        await File.WriteAllTextAsync("Person.json", json);

        var person2 = JsonSerializer.Deserialize<Person>(json, Options);
        Console.WriteLine(json);
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }

    public static JsonSerializerOptions Options => new()
    {
        ReadCommentHandling = JsonCommentHandling.Skip,
        WriteIndented = true
    };
}
