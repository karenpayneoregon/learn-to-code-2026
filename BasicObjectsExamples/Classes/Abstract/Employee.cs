namespace BasicObjectsExamples.Classes.Abstract;

public class Employee : Person
{
    public required string Title { get; set; }
    public override string ToString() => $"{Title} {FirstName} {LastName}";

}