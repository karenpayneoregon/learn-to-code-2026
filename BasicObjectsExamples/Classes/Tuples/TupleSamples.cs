using BogusLibrary.Models;
using System.Text.Json;
using Serilog;

namespace BasicObjectsExamples.Classes.Tuples;
public class TupleSamples
{
    /// <summary>
    /// Reads a list of users from a JSON file and returns the result as a tuple.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item>
    /// <description>An <see cref="Exception"/> object if an error occurs during file reading or deserialization; otherwise, <c>null</c>.</description>
    /// </item>
    /// <item>
    /// <description>A <see cref="List{T}"/> of <see cref="User"/> objects if the operation succeeds; otherwise, <c>null</c>.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// The method attempts to read a file named <c>Users.json</c> and deserialize its content into a list of <see cref="User"/> objects.
    /// If an exception occurs during the process, it is captured and returned as part of the tuple.
    /// </remarks>
    public static (Exception exception, List<User> users) ReadUsersFromFile()
    {
        try
        {
            var json = File.ReadAllText("Users.json");
            var users = JsonSerializer.Deserialize<List<User>>(json, Options);
            return (null, users);
        }
        catch (Exception e)
        {
            Log.Error(e,"An error occurred while reading the Users.json file.");
            return (e, null);
        }
    }

    public static JsonSerializerOptions Options => new()
    {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip
    };
    
    /// <summary>
    /// Retrieves information about a person as a tuple.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item>
    /// <description>The person's name as a <see cref="string"/>.</description>
    /// </item>
    /// <item>
    /// <description>The person's age as an <see cref="int"/>.</description>
    /// </item>
    /// <item>
    /// <description>The person's city of residence as a <see cref="string"/>.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <example>
    /// The following example demonstrates how to use the <see cref="GetPersonInfo"/> method:
    /// <code>
    /// var (name, age, city) = TupleSamples.GetPersonInfo();
    /// Console.WriteLine($"{name} is {age} years old and lives in {city}.");
    /// </code>
    /// </example>
    public static (string Name, int Age, string City) GetPersonInfo()
    {
        return ("Alice", 30, "Seattle");
    }
}
