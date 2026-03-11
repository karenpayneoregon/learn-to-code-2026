using BogusLibrary.Classes;
using BogusLibrary.Classes.Writers;

namespace GeneratorHumansSample;

internal class Program
{

    static void Main(string[] args)
    {
        
        var peeps = PersonGenerator.Create(20, true);
        PeopleFileWriter.WriteToFile(peeps, "people.txt");
        PeopleFileWriter.GenerateCommaDelimitedFile(peeps, "people.csv");
    }
}
