
namespace HttpClientApp.Classes;

/// <summary>
/// Represents a person with properties for name and age.
/// </summary>
/// <remarks>
/// Uses the <see cref="JsonCommentAttribute"/> to add comments to the JSON.    
/// </remarks>
public class Person
{
    [JsonComment("First Name of the person")]
    public required string FirstName { get; set; }

    [JsonComment("Last Name of the person")]
    public required string LastName { get; set; }

    [JsonComment("Birth date of the person")]
    public required DateOnly BirthDate { get; set; }

}