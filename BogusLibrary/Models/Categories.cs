#nullable disable

// ReSharper disable VirtualMemberCallInConstructor
namespace BogusLibrary.Models;

public class Categories
{
    public Categories()
    {
        Products = new HashSet<Products>();
    }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public virtual ICollection<Products> Products { get; set; }
    public override string ToString() => CategoryName;

}