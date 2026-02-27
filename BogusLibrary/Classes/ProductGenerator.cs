using Bogus;
using BogusLibrary.Models;
using static Bogus.Randomizer;
namespace BogusLibrary.Classes;

/// <summary>
/// Provides functionality to generate a list of products and their associated categories.
/// </summary>
/// <remarks>
/// This class is responsible for creating products with associated category navigation properties.
/// It also populates a collection of generated categories for further use.
/// </remarks>
public class ProductGenerator
{
    /// <summary>
    /// Categories generated during the last Create() call.
    /// </summary>
    public static List<Categories> GeneratedCategories { get; private set; } = [];

    /// <summary>
    /// Generate a list of Products with Category navigation set.
    /// Also populates GeneratedCategories.
    /// </summary>
    /// <param name="count">Number of products to generate.</param>
    /// <param name="random">
    /// false = deterministic (fixed seed, repeatable output)  
    /// true  = non-deterministic (different results each run)
    /// </param>
    public static List<Products> Create(int count, bool random = false)
    {
        if (count <= 0)
            return [];

        // Seed control for reproducibility vs full randomness
        Seed = !random ? new Random(338) : null;

        // 1. Generate some categories
        //    Adjust categoryCount as you like or make it a parameter later.
        const int categoryCount = 5;

        var categoryFaker = new Faker<Categories>()
            .StrictMode(true)
            .RuleFor(c => c.CategoryId, f => f.IndexFaker + 1) // 1..categoryCount
            .RuleFor(c => c.CategoryName, f => f.Commerce.Categories(1).First())
            .RuleFor(c => c.Products, f => new HashSet<Products>());

        GeneratedCategories = categoryFaker.Generate(categoryCount);

        // 2. Generate products and link them too categories
        var productFaker = new Faker<Products>()
            .StrictMode(true)
            .RuleFor(p => p.ProductId, f => f.IndexFaker + 1)
            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
            .RuleFor(p => p.CategoryId, f => f.PickRandom(GeneratedCategories).CategoryId)
            .RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price(1, 500)))
            .RuleFor(p => p.UnitsInStock, f => (short)f.Random.Int(0, 500))
            .RuleFor(p => p.Category, (f, p) => GeneratedCategories.First(c => c.CategoryId == p.CategoryId));

        var products = productFaker.Generate(count);

        // 3. Back-fill the Category.Products collections so navigation
        //    works both ways in memory.
        foreach (var category in GeneratedCategories)
        {
            var catProducts = products
                .Where(p => p.CategoryId == category.CategoryId)
                .ToList();

            // Categories constructor already initializes Products to HashSet<Products>,
            // but this makes sure it reflects the generated list.
            category.Products = new HashSet<Products>(catProducts);
        }

        return products;
    }
}