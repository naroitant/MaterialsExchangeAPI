using MaterialsExchangeAPI.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialsExchangeAPI.Domain.Entities;

[Table("materials")]
public class Material : BaseEntity
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public Seller? Seller { get; set; }
    public int SellerId { get; set; }
}
