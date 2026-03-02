using BogusLibrary.Classes;
using BogusLibrary.Models;
using KellermanSoftware.CompareNetObjects;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
#pragma warning disable IDE0130

namespace TestProject1;
public sealed partial class BogusGenerationTests
{
    private static Human _human;
    private static Human _testHuman;

    /// <summary>
    /// Initializes the test class by setting up necessary resources and configurations.
    /// </summary>
    /// <param name="testContext">
    /// The <see cref="TestContext"/> instance that provides information about the current test run.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the <see cref="HumanGenerator.Create(int,bool)"/> method does not
    /// return any items.
    /// </exception>
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        TestResults = new List<TestContext>();
        
        _human = HumanGenerator.Create(1).FirstOrDefault() ?? 
                 throw new InvalidOperationException(
                     "HumanGenerator.Create(1) did not return any items."); ;
        
        _testHuman = new Human
        {
            Id = 1,
            FirstName = "Marlon",
            LastName = "Balistreri",
            BirthDate = new DateOnly(2001, 12, 21),
            BirthDay = new DateTime(1988,7,21,6,14,43),
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
