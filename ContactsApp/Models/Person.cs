#nullable disable

namespace ContactsApp.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public short? GenderId { get; set; }

    public string Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public byte[] RowVersion { get; set; }

    public virtual Gender Gender { get; set; }

    public virtual ICollection<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();

    public virtual ICollection<PersonDevice> PersonDevices { get; set; } = new List<PersonDevice>();
}