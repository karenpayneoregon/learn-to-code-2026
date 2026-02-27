namespace BasicObjectsExamples.Classes.Simple;
// This class demonstrates the use of a primary constructor in C# 13.0
public class FileOperations(string folderName)
{
    public string FolderName { get; set; } = folderName;

    public void ReadFile(string fileName)
    {
        Console.WriteLine(Path.Combine(FolderName, fileName));
    }
}