namespace Application.Materials.Commands.UpdateMaterial;

public class UpdateMaterialCommandValidator
    : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotNull();

        RuleFor(m => m.Dto.Name)
            .NotEmpty();

        RuleFor(m => m.Dto.Price)
            .NotNull()
            .GreaterThan(0);

        RuleFor(m => m.Dto.SellerId)
            .NotNull();
    }
}
