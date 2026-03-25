#nullable disable

namespace ContactsApp.Models;

public partial class AddressType
{
    public short AddressTypeId { get; set; }

    public string AddressTypeName { get; set; }

    public virtual ICollection<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();
}