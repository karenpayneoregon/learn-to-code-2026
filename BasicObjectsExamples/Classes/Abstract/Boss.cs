using BasicObjectsExamples.Interfaces;

namespace BasicObjectsExamples.Classes.Abstract;

// abstract then interface (abstract must be first)
public class Boss : Manager, IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}