using FluentValidation;

namespace MaterialsExchangeAPI.Features.Material.Commands.CreateMaterialCommand
{
    public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
    {
        public CreateMaterialCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Price).NotNull().GreaterThan(0);
            RuleFor(m => m.SellerId).NotNull();
        }
    }
}
