using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialsExchange.Models.DTO
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

    public class MaterialDtoValidator : AbstractValidator<MaterialDto>
    {
        public MaterialDtoValidator()
        {
            RuleFor(m => m.Id).NotNull();
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Price).NotNull().GreaterThan(0);
            RuleFor(m => m.SellerId).NotNull();
        }
    }
}
