using Dumpify;
using Spectre.Console;
using IComparerIEqualityComparerApp.Classes.Core;
using IComparerIEqualityComparerApp.Models;
using Serilog;

namespace IComparerIEqualityComparerApp.Classes;
internal class Operations
{
    /// <summary>
    /// Displays distinct people from a predefined list based on their first name, last name, and birthdate.
    /// </summary>
    /// <remarks>
    /// This method creates a list of <see cref="Person"/> objects, filters out duplicates using the 
    /// <a href="https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinctby">DistinctBy</a> method, and prints the distinct people to the console using Spectre.Console.
    /// </remarks>
    public static void DistinctPeople()
    {
        SpectreConsoleHelpers.PrintCyan();

        var people = People();

        var distinctPeople = people.DistinctBy(x =>
        (
            x.FirstName,
            x.LastName,
            x.BirthDate
        )).ToList();

        distinctPeople.Dump();
    }

    private static List<Person> People()
    {
        var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "doe", BirthDate = new DateOnly(1990, 1, 1) },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", BirthDate = new DateOnly(1992, 2, 2) },
            new Person { Id = 3, FirstName = "john", LastName = "Doe", BirthDate = new DateOnly(1990, 1, 1) },
        };
        return people;
    }
}
