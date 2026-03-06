using Bogus;
using Bogus.DataSets;
using BogusLibrary.Models;
using Person = BogusLibrary.Models.Person;

namespace BogusLibrary.Classes;

/// <summary>
/// Provides functionality for generating realistic, randomized <see cref="Person"/> objects.
/// </summary>
/// <remarks>
/// This class leverages the Bogus library to create <see cref="Person"/> objects with various properties, 
/// including identifiers, names, gender, birthdates, email addresses, social security numbers, and associated addresses. 
/// It supports generating a specified number of <see cref="Person"/> objects with either deterministic or randomized data.
/// </remarks>
public class PersonGenerator
{

    /// <summary>
    /// Generates a list of randomized <see cref="Person"/> objects.
    /// </summary>
    /// <param name="count">The number of <see cref="Person"/> objects to generate.</param>
    /// <param name="random">
    /// A boolean value indicating whether the data should be randomized. 
    /// If <c>false</c>, a deterministic seed is used for reproducibility.
    /// </param>
    /// <returns>A list of <see cref="Person"/> objects with realistic, randomized data.</returns>
    /// <remarks>
    /// This method utilizes the Bogus library to create <see cref="Person"/> objects with various properties, 
    /// including identifiers, names, gender, birthdates, email addresses, social security numbers, and associated addresses.
    /// </remarks>
    public static List<Person> Create(int count, bool random = false)
    {
        if (!random)
        {
            Randomizer.Seed = new Random(338);
        }

        var today = DateTime.Now;
        var id = 1;

        var faker = new Faker<Person>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, u) => f.Name.FirstName((Name.Gender?)u.Gender))
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDay, f => f.Date.Between(new DateTime(1900, 1, 1), today))
            .RuleFor(c => c.BirthDate, f => f.Date.BetweenDateOnly(new DateOnly(1900, 1, 1), new DateOnly(today.Year, today.Month, today.Day)))
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
            .RuleFor(c => c.Gender, f => f.PickRandom<Gender>())
            .RuleFor(p => p.SocialSecurityNumber, f => f.Random.Replace("###-##-####").Replace("-",""))
            .RuleFor(p => p.Address, f => AddressGenerator.Create().FirstOrDefault());

        return faker.Generate(count);

    }
  
}