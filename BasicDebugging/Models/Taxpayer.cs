using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDebugging.Models;
internal class Taxpayer
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Gender { get; set; }
    public required decimal Income { get; set; }
    //public override string ToString() => $"{FirstName} {LastName}";

}