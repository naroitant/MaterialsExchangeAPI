using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialsExchangeAPI.Models.Domain
{
    [Table("materials")]
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Seller Seller { get; set; }
        public int SellerId { get; set; }
    }
}
