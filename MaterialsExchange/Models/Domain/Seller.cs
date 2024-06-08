using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialsExchange.Models.Domain
{
    [Table("sellers")]
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Material> Materials { get; set; } = new List<Material>();
    }
}
