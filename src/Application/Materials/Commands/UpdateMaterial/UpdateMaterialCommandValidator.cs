namespace Application.Materials.Commands.UpdateMaterial;

public class UpdateMaterialCommandValidator
    : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotNull();
        RuleFor(m => m.Name)
            .NotEmpty();
        RuleFor(m => m.Price)
            .NotNull()
            .GreaterThan(0);
        RuleFor(m => m.SellerId)
            .NotNull();
    }
}
