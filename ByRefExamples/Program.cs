using ByRefExamples.Classes;
using ByRefExamples.Classes.Configuration;
using ByRefExamples.Models;
using Spectre.Console;
using SpectreConsoleLibrary;
using System.ComponentModel;
using static SpectreConsoleLibrary.SpectreConsoleHelpers;
// ReSharper disable ConvertToConstant.Local
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace ByRefExamples;
internal partial class Program
{
    /// <summary>
    ///  - By value: You can modify the object’s contents but not which object the caller refers to.
    ///  - By ref: You can modify both the object’s contents and the caller’s reference itself.
    /// </summary>
    static void Main(string[] args)
    {

        // By value
        Person person = new() { Name = "John" };
        PersonOperations.ChangePerson(person);
        AnsiConsole.MarkupLine($"[yellow]By val[/] [cyan]{person.Name}[/]");  // Output: Alice

        Console.WriteLine();

        // By ref
        person = new() { Name = "John" };
        PersonOperations.ChangePersonByRef(ref person);
        AnsiConsole.MarkupLine($"[yellow]By ref[/] [cyan]{person.Name}[/]");  // Output: Bob

        NextValueByRef();
        NextValueByValue();

        ExitPrompt(Justify.Left);
        
    }

    private static void NextValueByRef()
    {
        PrintPink();
        
        var accountNumber = "ABC89";
        
        AnsiConsole.MarkupLine($"[yellow]{accountNumber}[/]");
        Helpers.NextValue(ref accountNumber);
        AnsiConsole.MarkupLine($"[yellow]{accountNumber}[/]");

        Console.WriteLine();
    }

    private static void NextValueByValue()
    {
        PrintPink();

        var accountNumber = "ABC89";

        AnsiConsole.MarkupLine($"[yellow]{accountNumber}[/]");
        accountNumber = Helpers.NextValue(accountNumber);
        AnsiConsole.MarkupLine($"[yellow]{accountNumber}[/]");

        Console.WriteLine();
    }


}


