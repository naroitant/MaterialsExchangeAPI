namespace MaterialsExchangeAPI.Domain.Entities;

public class Material
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Seller Seller { get; set; }
    public int SellerId { get; set; }
}
