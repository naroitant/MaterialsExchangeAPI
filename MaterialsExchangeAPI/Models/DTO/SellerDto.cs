using System.ComponentModel.DataAnnotations;

namespace MaterialsExchangeAPI.Models.DTO
{
    public class SellerDto
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
