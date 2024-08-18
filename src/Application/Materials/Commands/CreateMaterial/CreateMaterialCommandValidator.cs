namespace Application.Materials.Commands.CreateMaterial;

public class CreateMaterialCommandValidator
    : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(c => c.Dto.Name)
            .NotEmpty();

        RuleFor(c => c.Dto.Price)
            .NotNull()
            .GreaterThan(0);

        RuleFor(c => c.Dto.SellerId)
            .NotNull();
    }
}
