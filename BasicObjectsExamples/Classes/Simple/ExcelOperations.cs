namespace BasicObjectsExamples.Classes.Simple;

// This class demonstrates a simple class with a constructor and a method to read a files
public class ExcelOperations
{
    public string FileName { get; set; }

    public ExcelOperations(string fileName)
    {
        FileName = fileName;
    }

    public void ReadFile()
    {
        Console.WriteLine(FileName);
    }
}