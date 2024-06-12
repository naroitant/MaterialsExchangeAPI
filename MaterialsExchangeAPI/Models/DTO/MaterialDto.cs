using System.ComponentModel.DataAnnotations;

namespace MaterialsExchangeAPI.Models.DTO
{
    public class MaterialDto
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int SellerId { get; set; }
    }
}
