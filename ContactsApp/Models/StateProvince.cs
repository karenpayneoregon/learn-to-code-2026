#nullable disable

namespace ContactsApp.Models;

public partial class StateProvince
{
    public short StateProvinceId { get; set; }

    public short CountryId { get; set; }

    public string StateCode { get; set; }

    public string StateName { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; }
}