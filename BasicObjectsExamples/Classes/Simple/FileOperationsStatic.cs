namespace BasicObjectsExamples.Classes.Simple;

public class FileOperationsStatic
{

    public string FolderName => "C:\\Files\\SomeFile.txt";

    public void ReadFile(string fileName)
    {
        Console.WriteLine(Path.Combine(FolderName, fileName));
    }
}