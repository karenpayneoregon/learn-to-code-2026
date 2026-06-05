namespace InterfaceExamples.Interfaces;

internal interface IHuman
{
    
    string FirstName { get; set; }
    string LastName { get; set; }
    DateOnly BirthDate { get; set; }
}