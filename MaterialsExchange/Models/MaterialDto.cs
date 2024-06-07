using FluentValidation;

namespace MaterialsExchange.Models
{
	public class MaterialDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
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
