using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("sellers")]
public class Seller : BaseEntity
{
    public string Name { get; private set; }

    public List<Material> Materials { get; private set; } = new();

    public Seller(string name)
    {
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
    }

    public void UpdateMaterials(List<Material> materials)
    {
        Materials = materials;
    }
}
