

using BogusLibrary.Classes;
using BogusLibrary.Models;

namespace TestProject1.Classes;

/// <summary>
/// Represents the configuration settings for the application.
/// </summary>
/// <remarks>
/// This class is implemented as a singleton, ensuring that only one instance of the configuration exists
/// throughout the application's lifecycle. It provides access to predefined instances of <see cref="Human"/> 
/// and supports additional configuration options.
/// </remarks>
public sealed class TestConfiguration
{
    private static readonly Lazy<TestConfiguration> _instance = new(() => new TestConfiguration());

    public static TestConfiguration Instance => _instance.Value;

    /// <summary>
    /// Gets the predefined instance of the <see cref="Human"/> class used for testing.
    /// </summary>
    /// <remarks>
    /// This property provides access to a single instance of <see cref="Human"/> that is initialized
    /// during the construction of the <see cref="TestConfiguration"/> singleton. It is intended to
    /// represent a default or primary human configuration used throughout the testing.
    /// </remarks>
    public Human Human { get; init; }
    
    /// <summary>
    /// Gets the predefined instance of <see cref="Human"/> used for testing purposes.
    /// </summary>
    /// <remarks>
    /// This property provides a specific instance of the <see cref="Human"/> class, 
    /// initialized with predefined values. It is intended for use in testing scenarios 
    /// where a consistent and predictable <see cref="Human"/> object is required.
    /// </remarks>
    public Human TestHuman { get; init; }

    private TestConfiguration()
    {
        Human = HumanGenerator.Create(1).FirstOrDefault() ??
            throw new InvalidOperationException(
                "HumanGenerator.Create(1) did not return any items.");
        TestHuman = new Human
        {
            Id = 1,
            FirstName = "Marlon",
            LastName = "Balistreri",
            BirthDate = new DateOnly(2001, 12, 21),
            BirthDay = new DateTime(1988, 7, 21, 6, 14, 43),
            Email = "Marlon.Balistreri@hotmail.com",
            Gender = Gender.Male,
            SocialSecurityNumber = "793393519",
            Address = new Address
            {
                Id = 1,
                Street = "Price Heights",
                City = "West Angelo",
                State = "Virginia",
                ZipCode = "65553-7845",
                Country = "United Arab Emirates"
            }
        };
    }
}