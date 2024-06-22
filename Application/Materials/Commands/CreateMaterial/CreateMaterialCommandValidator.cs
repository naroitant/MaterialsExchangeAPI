namespace MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;

public class CreateMaterialCommandValidator
    : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.Price).NotNull().GreaterThan(0);
        RuleFor(m => m.SellerId).NotNull();
    }
}
