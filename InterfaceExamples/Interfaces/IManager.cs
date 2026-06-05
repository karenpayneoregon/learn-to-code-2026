using InterfaceExamples.Models;

namespace InterfaceExamples.Interfaces;

internal interface IManager
{
    List<Employee> Employees { get; set; }
}