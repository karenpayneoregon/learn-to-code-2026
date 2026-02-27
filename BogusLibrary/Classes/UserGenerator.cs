using Bogus;
using BogusLibrary.Models;
using static Bogus.Randomizer;

namespace BogusLibrary.Classes;

/// <summary>
/// Provides functionality for generating a list of <see cref="User"/> objects with realistic, randomized data.
/// </summary>
/// <remarks>
/// This class utilizes the Bogus library to create <see cref="User"/> objects with properties such as ID, name, and password.
/// It supports both deterministic and non-deterministic data generation based on the provided seed configuration.
/// </remarks>
public static class UserGenerator
{
    /// <summary>
    /// Generates a list of <see cref="User"/> objects with randomized data.
    /// </summary>
    /// <param name="count">
    /// The number of <see cref="User"/> objects to generate. Must be greater than zero.
    /// </param>
    /// <param name="random">
    /// A boolean value indicating whether to use non-deterministic randomization.
    /// If set to <c>false</c>, a fixed seed is used for deterministic results.
    /// </param>
    /// <returns>
    /// A list of <see cref="User"/> objects populated with realistic, randomized data.
    /// Returns an empty list if <paramref name="count"/> is less than or equal to zero.
    /// </returns>
    public static List<User> Create(int count, bool random = false)
    {
        if (count <= 0)
            return [];

        Seed = !random ? new Random(338) : null;

        var faker = new Faker<User>()
            .StrictMode(true)
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Name, f => f.Internet.UserName())
            .RuleFor(u => u.Password, f => f.Internet.Password(12, false));

        return faker.Generate(count);
    }
}