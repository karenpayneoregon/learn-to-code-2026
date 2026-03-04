namespace TestProject1.Base;

public enum Trait
{
    PlaceHolder,
    /// <summary>
    /// Represents a trait used for categorizing tests related to the Bogus library.
    /// </summary>
    Bogus,
    /// <summary>
    /// Represents a trait used for categorizing tests that validate functionality
    /// using the Shouldly assertion library in conjunction with Bogus data generation.
    /// </summary>
    BogusShouldly,
    /// <summary>
    /// Trait used for categorizing and filtering test methods for NuGet package CompareNETObjects.
    /// </summary>
    Keller,
    /// <summary>
    /// Represents a trait category for tests related to numeric operations or validations.
    /// </summary>
    Numbers,
    /// <summary>
    /// Represents a trait used to categorize tests related to application settings.
    /// </summary>
    AppSettings
}