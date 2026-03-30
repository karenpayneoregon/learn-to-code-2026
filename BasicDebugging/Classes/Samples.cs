using System.Diagnostics;
using BasicDebugging.Classes.Core;
using BasicDebugging.Models;
using Spectre.Console;

// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace BasicDebugging.Classes;
internal class Samples
{
    public static void Switch()
    {
        SpectreConsoleHelpers.PrintPink();
        
        List<string[]> ReadTransFromFile()
        {
            var items = new List<string[]>();
            var lines = File.ReadAllLines("Transactions.txt");

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                items.Add(parts);
            }

            return items;
        }

        List<string[]> records = ReadTransFromFile();
        decimal balance = 0m;

        foreach (string[] transaction in records)
        {
            balance += transaction switch
            {
                [_, "DEPOSIT", _, var amount] => GetDecimal(amount),
                [_, "WITHDRAWAL", .., var amount] => -GetDecimal(amount),
                [_, "INTEREST", var amount] => GetDecimal(amount),
                [_, "FEE", .., var fee] => -GetDecimal(fee),
                _ => throw new InvalidOperationException(
                    $"Record {string.Join(", ", transaction)} is invalid"),
            };

            if (balance < 1000)
            {
                AnsiConsole.MarkupLine($"[cyan]Record:[/] {string.Join(", ", transaction),-50} [white on red]Balance[/] {balance:C}");
            }
            else
            {
                AnsiConsole.MarkupLine($"[cyan]Record:[/] {string.Join(", ", transaction),-50} [yellow]Balance[/] {balance:C}");
            }

        }
    }

    static decimal GetDecimal(string sender)
        => decimal.TryParse(sender, out var value) ? value : 0;

    public static List<Taxpayer> GetTaxpayers()
    {
        return
        [
            new() { Id = 1, FirstName = "James", LastName = "Smith", Gender = "Male", Income = 55000m },
            new() { Id = 2, FirstName = "Mary", LastName = "Johnson", Gender = "Female", Income = 72000m },
            new() { Id = 3, FirstName = "Robert", LastName = "Williams", Gender = "Male", Income = 48000m },
            new() { Id = 4, FirstName = "Patricia", LastName = "Brown", Gender = "Female", Income = 91000m },
            new() { Id = 5, FirstName = "John", LastName = "Jones", Gender = "Male", Income = 61000m },
            new() { Id = 6, FirstName = "Jennifer", LastName = "Garcia", Gender = "Female", Income = 83000m },
            new() { Id = 7, FirstName = "Michael", LastName = "Miller", Gender = "Male", Income = 45000m },
            new() { Id = 8, FirstName = "Linda", LastName = "Davis", Gender = "Female", Income = 77000m },
            new() { Id = 9, FirstName = "William", LastName = "Rodriguez", Gender = "Male", Income = 68000m },
            new() { Id = 10, FirstName = "Elizabeth", LastName = "Martinez", Gender = "Female", Income = 95000m },
            new() { Id = 11, FirstName = "David", LastName = "Hernandez", Gender = "Male", Income = 53000m },
            new() { Id = 12, FirstName = "Barbara", LastName = "Lopez", Gender = "Female", Income = 64000m },
            new() { Id = 13, FirstName = "Richard", LastName = "Gonzalez", Gender = "Male", Income = 88000m },
            new() { Id = 14, FirstName = "Susan", LastName = "Wilson", Gender = "Female", Income = 72000m },
            new() { Id = 15, FirstName = "Joseph", LastName = "Anderson", Gender = "Male", Income = 59000m },
            new() { Id = 16, FirstName = "Jessica", LastName = "Thomas", Gender = "Female", Income = 81000m },
            new() { Id = 17, FirstName = "Thomas", LastName = "Taylor", Gender = "Male", Income = 47000m },
            new() { Id = 18, FirstName = "Sarah", LastName = "Moore", Gender = "Female", Income = 86000m },
            new() { Id = 19, FirstName = "Charles", LastName = "Jackson", Gender = "Male", Income = 69000m },
            new() { Id = 20, FirstName = "Karen", LastName = "White", Gender = "Female", Income = 78000m }
        ];
    }

    public static void LoopTaxpayers()
    {
        
        SpectreConsoleHelpers.PrintPink();   
        
        var taxpayers = GetTaxpayers();

        foreach (var taxpayer in taxpayers)
        {
            //Debug.WriteLine($"{taxpayer.Income:C}");
        }
    }

    public static void HitCount()
    {
        SpectreConsoleHelpers.PrintPink();

        var taxpayers = GetTaxpayers();

        foreach ((int Index, Taxpayer taxpayer)  in taxpayers.Index())
        {
            AnsiConsole.MarkupLine($"[bold]{Index, -3}[/] {taxpayer.FirstName, -10} " +
                                   $"{taxpayer.LastName, -12}  {taxpayer.Income:C}");
        }


    }
}

