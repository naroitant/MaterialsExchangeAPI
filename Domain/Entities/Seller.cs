namespace MaterialsExchangeAPI.Domain.Entities;

public class Seller
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Material> Materials { get; set; } = new List<Material>();
}
