using FluentValidation;

namespace MaterialsExchange.Models
{
	public class SellerDto
	{
		public int Id { get; set; }
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
