namespace BasicObjectsExamples.Classes.Abstract;

public abstract class Manager
{
    public List<Employee> Employees { get; set; } = new List<Employee>();
}