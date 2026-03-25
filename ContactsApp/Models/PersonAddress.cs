#nullable disable
namespace ContactsApp.Models;

public partial class PersonAddress
{
    public int PersonAddressId { get; set; }

    public int PersonId { get; set; }

    public int AddressId { get; set; }

    public short AddressTypeId { get; set; }

    public bool IsPrimary { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Address Address { get; set; }

    public virtual AddressType AddressType { get; set; }

    public virtual Person Person { get; set; }
}