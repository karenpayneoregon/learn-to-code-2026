using ContactsApp.Classes.Core;
using ContactsApp.Data;
using ContactsApp.Extensions;
using ContactsApp.Models;
using ContactsDataLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Classes;
internal class PersonOperations
{
    public static bool ShowInPlace => true;
    public static async Task<List<Person>> DisplayPeople()
    {

        SpectreConsoleHelpers.PrintPink();
        
        await using var context = new Context();

        var people = await context.People
            .AsNoTracking()
            .Include(p => p.PersonAddresses)
            .ThenInclude(pa => pa.Address)
            .ThenInclude(a => a.StateProvince)
            .Include(p => p.PersonAddresses)
            .ThenInclude(pa => pa.AddressType)
            .Include(p => p.Gender)
            .Include(p => p.PersonDevices)
            .ThenInclude(pd => pd.Device)
            .ThenInclude(d => d.DeviceType)
            .ToListAsync();

        if (ShowInPlace)
        {
            SpectreConsoleHelpers.InfoPill(Justify.Left, "Generated People Data");


            foreach (Person p in people)
            {

                AnsiConsole.MarkupLine($"[cyan]{p.PersonId,-4}{p.FirstName,-12}{p.LastName,-14}" +
                                       $"{p.DateOfBirth,-30:MM/dd/yyyy}{p.Gender?.GenderName}[/]");

                foreach (PersonAddress? pa in p.PersonAddresses)
                {

                    Console.WriteLine($"  {pa.Address.AddressLine1,-28}{pa.Address?.City,-30}" +
                                      $"{pa.Address?.StateProvince.StateName,-20}" +
                                      $"{pa.AddressType.AddressTypeName,-15}" +
                                      $"{pa.IsPrimary.IsPrimaryAddress()}");

                }

                foreach (PersonDevice? pd in p.PersonDevices)
                {

                    AnsiConsole.MarkupLine($"  {pd.Device.DeviceType.DeviceTypeName,-28}{pd.Device.DeviceValue,-30}" +
                                           $"{pd.StartDate,-12:MM/dd/yyyy}" +
                                           $"{(pd.IsPrimary ? "[green]Primary[/]" : "[red]Secondary[/]")}");

                }

                Console.WriteLine();

            }



            Console.WriteLine();

        }

        return people;
    }

    public static void WithDebugView()
    {

        SpectreConsoleHelpers.PrintPink();
        
        using var context = new Context();
        
        Person person = new Person()
        {
            PersonId = 0,
            FirstName = "John",
            LastName = "Doe",
            MiddleName = "M",
            DateOfBirth = new DateTime(1990, 5, 15),
            GenderId = 1, // Assuming 1 is for Male
            Notes = "Test Person",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            RowVersion = Array.Empty<byte>(),
            PersonAddresses = new List<PersonAddress>()
            {
                new PersonAddress()
                {
                    Address = new Address()
                    {
                        AddressLine1 = "123 Main St",
                        City = "Anytown",
                        StateProvince = new StateProvince()
                        {
                            StateName = "CA"
                        }
                    },
                    AddressType = new AddressType()
                    {
                        AddressTypeName = "Home"
                    },
                    IsPrimary = true
                }
            }

        };

        context.People.Add(person);
        
        var view = context.ChangeTracker.DebugView.LongView;
        Console.WriteLine(view);
    }
    
    public static async Task<Person?> GetPerson(int id)
    {

        SpectreConsoleHelpers.PrintPink();
        
        await using var context = new Context();

        Person? person = await context.People
            .AsNoTracking()
            .TagWithDebugInfo(nameof(GetPerson))
            .Include(p => p.PersonAddresses)
            .ThenInclude(pa => pa.Address)
            .ThenInclude(a => a.StateProvince)
            .Include(p => p.PersonAddresses)
            .ThenInclude(pa => pa.AddressType)
            .Include(p => p.Gender)
            .Include(p => p.PersonDevices)
            .ThenInclude(pd => pd.Device)
            .ThenInclude(d => d.DeviceType)
            .FirstOrDefaultAsync(x => x.PersonId == id);

        return person;

    }

    private static async Task<List<PersonAddress>> GetPersonAddresses(int id)
    {

        SpectreConsoleHelpers.PrintPink();
        
        await using var context = new Context();

        List<PersonAddress> personAddresses = context.PersonAddresses
            .AsNoTracking()
            .Where(pa => pa.PersonId == id)
            .Include(pa => pa.Address)
            .ThenInclude(a => a.StateProvince)
            .Include(pa => pa.AddressType)
            .ToList();

        if (ShowInPlace)
        {
            SpectreConsoleHelpers.InfoPill(Justify.Left, $"Addresses for Person ID: {id}");

            foreach (var pa in personAddresses)
            {
                AnsiConsole.MarkupLine($"    [yellow]  Address Type:[/] {pa.AddressType.AddressTypeName}");
                AnsiConsole.MarkupLine($"    [cyan]Address Line 1:[/] {pa.Address.AddressLine1}");
                AnsiConsole.MarkupLine($"    [cyan]          City:[/] {pa.Address?.City}");
                AnsiConsole.MarkupLine($"    [cyan]         State:[/] {pa.Address?.StateProvince.StateName}");
                AnsiConsole.MarkupLine($"    [cyan]       Primary:[/] {pa.IsPrimary.IsPrimaryAddress()}");
            }
            
        }
        
        return personAddresses;
    }

    /// <summary>
    /// Retrieves and displays the devices associated with a specific person.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the person whose devices are to be retrieved.
    /// </param>
    /// <remarks>
    /// This method queries the database for devices linked to the specified person ID.
    /// It includes related data such as device types and displays the information
    /// in a formatted console output using Spectre.Console.
    /// </remarks>
    private static async Task<List<PersonDevice>> GetPersonDevices(int id)
    {

        SpectreConsoleHelpers.PrintPink();
        
        await using var context = new Context();

        List<PersonDevice> personDevices = await context.PersonDevices
            .AsNoTracking()
            .Where(pd => pd.PersonId == id)
            .Include(pd => pd.Device)
            .ThenInclude(d => d.DeviceType)
            .ToListAsync();

        if (ShowInPlace)
        {
            SpectreConsoleHelpers.InfoPill(Justify.Left, $"Devices for Person ID: {id}");

            foreach (var pd in personDevices)
            {
                AnsiConsole.MarkupLine($"  [yellow]Device Type:[/]{pd.Device.DeviceType.DeviceTypeName}");
                AnsiConsole.WriteLine($"    [cyan]Device Value:[/]{pd.Device.DeviceValue}");
                Console.WriteLine($"    [cyan]Start Date:[/]{pd.StartDate?.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"    [cyan]Primary:[/]{(pd.IsPrimary ? "[green]Yes[/]" : "[red]No[/]")}");
            }
        }

        return personDevices;
    }

 
    public static async Task<List<DeviceType>> GetDeviceTypes()
    {
        await using var context = new Context();
        return await context.DeviceTypes
            .AsNoTracking()
            .ToListAsync();
    }


    public static async Task<List<AddressType>> GetAddressTypes()
    {
        await using var context = new Context();
        return await context.AddressTypes
            .AsNoTracking()
            .ToListAsync();
    }


    public static async Task<List<Country>> GetCountries()
    {
        await using var context = new Context();
        return await context.Countries
            .AsNoTracking()
            .ToListAsync();
    }

 
    public static async Task<List<StateProvince>> GetStateProvinces()
    {
        await using var context = new Context();
        return await context.StateProvinces
            .AsNoTracking()
            .ToListAsync();
    }

}
