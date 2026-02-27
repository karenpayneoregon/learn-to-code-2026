#nullable disable

namespace BogusLibrary.Models;

public class Products
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int? CategoryId { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }

    public virtual Categories Category { get; set; }
    public override string ToString() => ProductName;

}