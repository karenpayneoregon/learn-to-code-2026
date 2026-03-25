#nullable disable

namespace ContactsApp.Models;

public partial class Device
{
    public int DeviceId { get; set; }

    public short DeviceTypeId { get; set; }

    public string DeviceValue { get; set; }

    public string Extension { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public byte[] RowVersion { get; set; }

    public virtual DeviceType DeviceType { get; set; }

    public virtual ICollection<PersonDevice> PersonDevices { get; set; } = new List<PersonDevice>();
}