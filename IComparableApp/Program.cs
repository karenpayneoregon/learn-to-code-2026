using System.Text.Json;
using IComparableApp.Classes;
using IComparableApp.Classes.Core;
using IComparableApp.Comparers;
using IComparableApp.Models;
using Spectre.Console;

namespace IComparableApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        DisplaySortedAccounts();
        Console.WriteLine();
        ShowSortedBankAccounts();
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }

    /// <summary>
    /// Displays a sorted list of bank accounts in a tabular format.
    /// </summary>
    /// <remarks>
    /// This method creates an array of <see cref="BankAccount"/> objects, sorts them using a custom comparer 
    /// (by balance), and displays the sorted accounts in a table using Spectre.Console.
    /// </remarks>
    private static void ShowSortedBankAccounts()
    {

        SpectreConsoleHelpers.PrintPinkSimple();

        var accounts = MockedData.AccountsFromFile();

        if (accounts is null)
        {
            SpectreConsoleHelpers.InfoPill(Justify.Left, "No accounts found.");
            return;
        }
        
        accounts[0] = new BankAccount { Name = "Jack", Balance = 8150.08M };
        var comparer = new BalanceComparer();
        Array.Sort(accounts, comparer);

        var grid = new Table { Border = TableBorder.Rounded };
        grid.AddColumn("[yellow]Name[/]");
        grid.AddColumn(new TableColumn("[yellow]Balance[/]").RightAligned());

        foreach (var account in accounts)
        {
            grid.AddRow(account.Name, account.Balance.ToString("C"));
        }

        AnsiConsole.Write(grid);
    }

    /// <summary>
    /// Displays a sorted list of bank accounts in a tabular format.
    /// </summary>
    /// <remarks>
    /// This method creates an array of <see cref="BankAccount"/> objects, sorts them by balance and then by name, 
    /// and displays the sorted accounts in a table using Spectre.Console.
    /// </remarks>
    private static void DisplaySortedAccounts()
    {

        SpectreConsoleHelpers.PrintPinkSimple();

        var accounts = MockedData.AccountsFromFile();

        if (accounts is null)
        {
            SpectreConsoleHelpers.InfoPill(Justify.Left, "No accounts found.");
            return;
        }

        // Sort by Balance, then Name
        var sortedAccounts = accounts
            .OrderBy(x => x.Balance)
            .ThenBy(x => x.Name)
            .ToList();

        var grid = new Table { Border = TableBorder.Rounded };
        grid.AddColumn("[yellow]Name[/]");
        grid.AddColumn(new TableColumn("[yellow]Balance[/]").RightAligned());

        foreach (var account in sortedAccounts)
        {
            grid.AddRow(account.Name, account.Balance.ToString("C"));
        }

        AnsiConsole.Write(grid);
    }

}