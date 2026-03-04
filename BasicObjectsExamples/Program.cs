
using BasicObjectsExamples.Classes.Abstract;
using BasicObjectsExamples.Classes.Deconstruction;
using BasicObjectsExamples.Classes.Simple;
using BasicObjectsExamples.Classes.Tuples;
using BasicObjectsExamples.Interfaces;
using BogusLibrary.Classes;
using Spectre.Console;
using SpectreConsoleLibrary;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression



namespace BasicObjectsExamples;
internal partial class Program
{
    static void Main(string[] args)
    {
        SimpleClassesSamples();
        
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }

    private static void SimpleClassesSamples()
    {
        var warming = ApplicationSettings.Instance.FolderName;
        
        FileOperations fileOps1 = new("C:\\Files");
        fileOps1.ReadFile("example.txt");
        
        FileOperations fileOps2 = new FileOperations(ApplicationSettings.Instance.FolderName);
        fileOps2.ReadFile("example.txt");
        
        ExcelOperations excelOps1 = new("data.xlsx");
        excelOps1.ReadFile();
        
        ExcelOperations excelOps2 = new ExcelOperations(ApplicationSettings.Instance.FileName);
        excelOps2.ReadFile();
    }

    /// <summary>
    /// Example of creating an instance of the Employee class,
    /// which inherits from the abstract Person class.
    /// </summary>
    private static void CreateEmployee()
    {
        Employee employee = new()
        {
            FirstName = "John", 
            LastName = "Doe", 
            Title = "Software Engineer"
        };
    }

    /// <summary>
    /// Example of creating an instance of the Boss class,
    /// which inherits from the abstract <see cref="Manager"/> class and implements
    /// the <see cref="IPerson"/> interface.
    /// </summary>
    private static void CreateBossWithEmployees()
    {
        Boss boss = new()
        {
            FirstName = "Jane",
            LastName = "Smith",
            Employees =
            [
                new Employee
                {
                    FirstName = "Alice", 
                    LastName = "Johnson", 
                    Title = "Developer"
                },
                new Employee
                {
                    FirstName = "Bob", 
                    LastName = "Williams", 
                    Title = "QA Tester"
                }
            ]
        };
    }

    #region Deconstruct sample

    private static void ExtractPersonDetails()
    {
        // point out discards
        var (id, fullName, birthDate) = GetPerson();
    }

    private static DP.Person GetPerson()
    {
        DP.Person person = new()
        {
            Firstname = "Karen",
            Lastname = "Payne",
            BirthDate = new DateOnly(1956,9,24)
        };

        return person;
    }

    #endregion

    private static void TupleExample()
    {
        var (exception, users) = TupleSamples.ReadUsersFromFile();

        if (exception != null)
        {
            AnsiConsole.MarkupLine($"[red]Error reading users:[/] {exception.Message}");
        }else
        {
            AnsiConsole.MarkupLine($"[green]Successfully read {users.Count} users from file.[/]");
        }

        
        AnsiConsole.MarkupLine($"[yellow bold]{new string('-',50)}[/]");
        
        

        var (name, age, city) = TupleSamples.GetPersonInfo();
        AnsiConsole.MarkupLine($"[DeepPink1]{name}[/] is [DeepPink1]{age}[/] and lives in [DeepPink1]{city}[/]");

    }

    private static void VirtualExample()
    {
        VM.Employee regularEmployee = new VM.Employee();
        VM.Employee managerAsEmployee = new VM.Manager();

        AnsiConsole.MarkupLine($"[DeepPink1]Employee Bonus:[/] {regularEmployee.Bonus:C2}");
        AnsiConsole.MarkupLine($"[DeepPink1]Manager Bonus:[/] {managerAsEmployee.Bonus:C2}");
    }
}
