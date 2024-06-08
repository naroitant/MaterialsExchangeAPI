using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace MaterialsExchange.Models.DTO
{
    public class SellerDto
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class SellerDtoValidator : AbstractValidator<SellerDto>
    {
        public SellerDtoValidator()
        {
            RuleFor(s => s.Id).NotNull();
            RuleFor(s => s.Name).NotEmpty();
        }
    }
}
