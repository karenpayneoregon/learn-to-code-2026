#nullable disable

namespace ContactsApp.Models;

public partial class Country
{
    public short CountryId { get; set; }

    public string CountryName { get; set; }

    public string CountryCode2 { get; set; }

    public virtual ICollection<StateProvince> StateProvinces { get; set; } = new List<StateProvince>();
}