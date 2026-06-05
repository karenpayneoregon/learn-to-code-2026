using InterfaceExamples.Interfaces;

namespace InterfaceExamples.Models;
internal class Customer : IHuman, IIdentity
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}
