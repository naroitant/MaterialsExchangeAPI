namespace Application.Materials.Commands.CreateMaterial;

public class CreateMaterialCommandValidator
    : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(m => m.Dto.Name)
            .NotEmpty();

        RuleFor(m => m.Dto.Price)
            .NotNull()
            .GreaterThan(0);

        RuleFor(m => m.Dto.SellerId)
            .NotNull();
    }
}
