#nullable disable
namespace ContactsApp.Models;

public partial class Gender
{
    public short GenderId { get; set; }

    public string GenderName { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}