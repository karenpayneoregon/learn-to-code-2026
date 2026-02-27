using Bogus;
using BogusLibrary.Models;
using static Bogus.Randomizer;

namespace BogusLibrary.Classes;

/// <summary>
/// Provides functionality to generate a collection of <see cref="BogusLibrary.Models.Categories"/> objects.
/// </summary>
/// <remarks>
/// This class utilizes the Bogus library to create fake data for <see cref="BogusLibrary.Models.Categories"/> objects.
/// It supports both deterministic and random data generation based on the specified parameters.
/// </remarks>
public class CategoryGenerator
{

    /// <summary>
    /// Generates a list of <see cref="Categories"/> objects with specified count.
    /// </summary>
    /// <param name="count">
    /// The number of <see cref="Categories"/> objects to generate. Must be greater than 0.
    /// </param>
    /// <param name="random">
    /// A boolean value indicating whether to use random seeding for generation.
    /// If <c>false</c>, a deterministic seed is used.
    /// </param>
    /// <returns>
    /// A list of generated <see cref="Categories"/> objects. Returns an empty list if <paramref name="count"/> is less than or equal to 0.
    /// </returns>
    public static List<Categories> Create(int count, bool random = false)
    {
        if (count <= 0)
            return [];

        // deterministic output
        Seed = !random ? new Random(338) : null;
        
        var faker = new Faker<Categories>()
            .StrictMode(true)
            .RuleFor(c => c.CategoryId, f => f.IndexFaker + 1) // sequential IDs
            .RuleFor(c => c.CategoryName, f => f.Commerce.Categories(1).First())
            .RuleFor(c => c.Products, f => new HashSet<Products>()); // always empty

        return faker.Generate(count);
    }
}