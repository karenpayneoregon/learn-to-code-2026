using BogusLibrary.Models;

namespace BogusLibrary.Classes;
public static class PeopleFileWriter
{
    /// <summary>
    /// Writes a list of <see cref="Person"/> objects to a file in a formatted manner.
    /// </summary>
    /// <param name="people">
    /// A list of <see cref="Person"/> objects to be written to the file.
    /// </param>
    /// <param name="filePath">
    /// The path of the file where the data will be written.
    /// </param>
    /// <remarks>
    /// Each <see cref="Person"/> object is written with its properties formatted and aligned.
    /// The file includes details such as ID, name, gender, birth date, social security number, email, 
    /// and address information.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="people"/> or <paramref name="filePath"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="IOException">
    /// Thrown if an I/O error occurs while writing to the file.
    /// </exception>
    /// <example>
    /// <code>
    /// var people = PersonGenerator.Create(10);
    /// PeopleFileWriter.WriteToFile(people, "output.txt");
    /// </code>
    /// </example>
    public static void WriteToFile(List<Person> people, string filePath)
    {
        using var writer = new StreamWriter(filePath);

        foreach (var person in people)
        {
            writer.WriteLine($"Id{new string(' ', 30 - "Id".Length)}{person.Id}");
            writer.WriteLine($"FirstName{new string(' ', 30 - "FirstName".Length)}{person.FirstName}");
            writer.WriteLine($"LastName{new string(' ', 30 - "LastName".Length)}{person.LastName}");
            writer.WriteLine($"Gender{new string(' ', 30 - "Gender".Length)}{person.Gender}");
            writer.WriteLine($"BirthDate{new string(' ', 30 - "BirthDate".Length)}{person.BirthDate}");
            var ssn = person.SocialSecurityNumber?.Replace("-", "") ?? string.Empty;
            writer.WriteLine($"SocialSecurityNumber{new string(' ', 30 - "SocialSecurityNumber".Length)}{ssn}");
            writer.WriteLine($"Email{new string(' ', 30 - "Email".Length)}{person.Email}");
            writer.WriteLine("Address");
            writer.WriteLine($"Street{new string(' ', 30 - "Street".Length)}{person.Address.Street}");
            writer.WriteLine($"City{new string(' ', 30 - "City".Length)}{person.Address.City}");
            writer.WriteLine($"State{new string(' ', 30 - "State".Length)}{person.Address.State}");
            writer.WriteLine($"ZipCode{new string(' ', 30 - "ZipCode".Length)}{person.Address.ZipCode}");

            writer.WriteLine(new string('-', 50));
        }
    }
}