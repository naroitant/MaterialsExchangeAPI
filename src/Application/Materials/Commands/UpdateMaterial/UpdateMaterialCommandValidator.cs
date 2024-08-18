namespace Application.Materials.Commands.UpdateMaterial;

public class UpdateMaterialCommandValidator
    : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull();

        RuleFor(c => c.Dto.Name)
            .NotEmpty();

        RuleFor(c => c.Dto.Price)
            .NotNull()
            .GreaterThan(0);

        RuleFor(c => c.Dto.SellerId)
            .NotNull();
    }
}
