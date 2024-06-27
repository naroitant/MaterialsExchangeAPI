using MaterialsExchangeAPI.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialsExchangeAPI.Domain.Entities;

[Table("materials")]
public class Material : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public Seller? Seller { get; private set; }
    public int SellerId { get; private set; }

    public Material(string name, decimal price, int sellerId)
    {
        Name = name;
        Price = price;
        SellerId = sellerId;
    }

    public static Material Create(string name, decimal price, int sellerId)
    {
        var material = new Material(name, price, sellerId);
        return material;
    }

    public void Update(string name, decimal price, int sellerId)
    {
        Name = name;
        Price = price;
        SellerId = sellerId;
    }

    public void UpdatePriceRandomly(int minRange, int maxRange)
    {
        Random rand = new();
        Price = rand.Next(minRange, maxRange);
    }
}
