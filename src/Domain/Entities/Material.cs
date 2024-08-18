using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("materials")]
public class Material : BaseEntity
{
    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public Seller? Seller { get; set; }

    public int SellerId { get; private set; }

    public Material(string name, decimal price, int sellerId)
    {
        Name = name;
        Price = price;
        SellerId = sellerId;
    }

    public void Update(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public void UpdatePriceRandomly()
    {
        const int minValue = 1;
        const int maxValue = 100;
        Random rand = new();
        
        Price = rand.Next(minValue, maxValue);
    }
}
