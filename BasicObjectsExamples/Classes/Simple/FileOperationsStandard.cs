namespace BasicObjectsExamples.Classes.Simple;

public class FileOperationsStandard
{
    public FileOperationsStandard(string folderName)
    {
        FolderName = folderName;
    }
    public string FolderName { get; set; }

    public void ReadFile(string fileName)
    {
        Console.WriteLine(Path.Combine(FolderName, fileName));
    }
}