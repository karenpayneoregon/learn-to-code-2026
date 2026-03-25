#nullable disable
namespace ContactsApp.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string City { get; set; }

    public short StateProvinceId { get; set; }

    public string PostalCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public byte[] RowVersion { get; set; }

    public virtual ICollection<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();

    public virtual StateProvince StateProvince { get; set; }
}