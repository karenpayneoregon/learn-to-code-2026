using BogusLibrary.Classes;

namespace GeneratorHumansSample;

internal class Program
{

    static void Main(string[] args)
    {
        
        var peeps = PersonGenerator.Create(20, true);
        PeopleFileWriter.WriteToFile(peeps, "people.txt");

    }
}
