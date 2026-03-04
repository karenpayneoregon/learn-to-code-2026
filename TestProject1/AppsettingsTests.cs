using TestProject1.Base;
using TeamSettingsLibrary.Classes;
namespace TestProject1;

[TestClass]
public class AppsettingsTests
{
    /// <summary>
    /// Validates that the server name retrieved from the application settings
    /// matches the expected value.
    /// </summary>
    /// <remarks>
    /// This test ensures that the <see cref="ConfigurationRootHelper.ServerName"/> method
    /// correctly retrieves the server name from the application's configuration file.
    /// </remarks>
    /// <example>
    /// The expected server name is "localhost". This test verifies that the actual value
    /// returned by the configuration helper matches this expected value.
    /// </example>
    [TestMethod]
    [TestTraits(Trait.AppSettings)]
    public void Read_ApplicationSettings_ServerTest()
    {
        // arrange
        const string expected = "localhost";

        // act
        var actual = ConfigurationRootHelper.ServerName();
        // assert
        Assert.AreEqual(expected, actual);
    }
    
    /// <summary>
    /// Validates that the catalog name retrieved from the application settings
    /// matches the expected value.
    /// </summary>
    /// <remarks>
    /// This test ensures that the <see cref="ConfigurationRootHelper.Catalog"/> method
    /// correctly retrieves the catalog name from the application's configuration file.
    /// </remarks>
    /// <example>
    /// The expected catalog name is "NorthWind2024". This test verifies that the actual value
    /// returned by the configuration helper matches this expected value.
    /// </example>
    [TestMethod]
    [TestTraits(Trait.AppSettings)]
    public void Read_ApplicationSettings_CatalogTest()
    {
        // arrange
        const string expected = "NorthWind2024";

        // act
        var actual = ConfigurationRootHelper.Catalog();
        // assert
        Assert.AreEqual(expected, actual);
    }
}