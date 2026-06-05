using CommonHelpersLibrary.Classes;
using InterfaceExamples.Classes;
using InterfaceExamples.Classes.Core;
using InterfaceExamples.Interfaces;
using InterfaceExamples.Models;
using Spectre.Console;

namespace InterfaceExamples;
internal partial class Program
{
    // See also: CommonHelpersLibrary project
    static void Main(string[] args)
    {

        var classEntityNames = InterfaceHelpers.GetAllEntityNames<IHuman>();

        var table = new Table().Border(TableBorder.None)
            .AddColumn("[yellow u]Class name[/]")
            .AddColumn("");

        foreach (var (index, className) in classEntityNames.Index())
        {
            table.AddRow(index.IsOdd() ? $"[bold]{className}[/]" : $"[cyan]{className}[/]");
        }

        AnsiConsole.Write(table);

        Console.WriteLine();
        
        var validate = InterfaceHelpers.ImplementsInterfaces<Manager>(
            [typeof(IHuman), typeof(IManager), typeof(IIdentity)]);
        
        AnsiConsole.MarkupLine(validate
            ? "[green bold]The Manager class implements required interfaces.[/]"
            : "[red bold]The Manager class does not implement required interfaces.[/]");

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
}
