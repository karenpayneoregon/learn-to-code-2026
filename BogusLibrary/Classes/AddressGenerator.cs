using Bogus;
using BogusLibrary.Models;

namespace BogusLibrary.Classes;

/// <summary>
/// Provides functionality for generating random address data using the Bogus library.
/// </summary>
/// <remarks>
/// This class is designed to create a collection of <see cref="Address"/> objects with randomly populated fields.
/// It leverages the Bogus library to generate realistic address data, including street names, cities, states, and more.
/// </remarks>
public static class AddressGenerator
{
    /// <summary>
    /// Creates a list of <see cref="Address"/> objects with randomly generated data.
    /// </summary>
    /// <param name="count">
    /// The number of <see cref="Address"/> objects to generate. Defaults to 1 if not specified.
    /// </param>
    /// <param name="random">
    /// A boolean value indicating whether to use a random seed for data generation. 
    /// If <c>false</c>, a fixed seed is used for reproducible results.
    /// </param>
    /// <returns>
    /// A list of <see cref="Address"/> objects populated with random data.
    /// </returns>
    public static List<Address> Create(int count = 1, bool random = false)
    {

        if (!random)
        {
            Randomizer.Seed = new Random(337);
        }

        var faker = new Faker<Address>()
            .RuleFor(a => a.Id, f => f.IndexFaker + 1)
            .RuleFor(a => a.Street, f => f.Address.StreetAddress())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.State, f => f.Address.State())
            .RuleFor(a => a.ZipCode, f => f.Address.ZipCode())
            .RuleFor(a => a.Country, f => f.Address.Country());

        return faker.Generate(count);
    }
}
