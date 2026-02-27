#nullable disable
namespace BogusLibrary.Models;

/// <summary>
/// Represents a product item with details such as its identifier, name, and unit price.
/// </summary>
/// <remarks>
/// This class provides functionality to convert from a <see cref="Products"/> instance
/// to a <see cref="ProductItem"/> instance. It also overrides the <see cref="ToString"/> method
/// to return the product name.
/// </remarks>
public class ProductItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal? UnitPrice { get; set; }
    public override string ToString() => Name;

    /// <summary>
    /// Defines an implicit conversion from a <see cref="Products"/> instance to a <see cref="ProductItem"/> instance.
    /// </summary>
    /// <param name="product">The <see cref="Products"/> instance to convert.</param>
    /// <returns>
    /// A new <see cref="ProductItem"/> instance with values mapped from the specified <see cref="Products"/> instance.
    /// </returns>
    public static implicit operator ProductItem(Products product) =>
        new()
        {
            Id = product.ProductId,
            Name = product.ProductName,
            UnitPrice = product.UnitPrice
        };
}