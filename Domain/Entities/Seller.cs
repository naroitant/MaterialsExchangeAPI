using MaterialsExchangeAPI.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialsExchangeAPI.Domain.Entities;

[Table("sellers")]
public class Seller : BaseEntity
{
    public string? Name { get; set; }
    public List<Material>? Materials
    {
        get; set;
    }
}
