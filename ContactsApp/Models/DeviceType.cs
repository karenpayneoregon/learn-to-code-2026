#nullable disable

namespace ContactsApp.Models;

public partial class DeviceType
{
    public short DeviceTypeId { get; set; }

    public string DeviceTypeName { get; set; }

    public string DeviceKind { get; set; }

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}