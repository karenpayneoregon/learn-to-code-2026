#nullable disable

namespace ContactsApp.Models;

public partial class PersonDevice
{
    public int PersonDeviceId { get; set; }

    public int PersonId { get; set; }

    public int DeviceId { get; set; }

    public bool IsPrimary { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Device Device { get; set; }

    public virtual Person Person { get; set; }
}