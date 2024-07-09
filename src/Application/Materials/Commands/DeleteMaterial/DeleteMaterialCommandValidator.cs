namespace Application.Materials.Commands.DeleteMaterial;

public class DeleteMaterialCommandValidator
    : AbstractValidator<DeleteMaterialCommand>
{
    public DeleteMaterialCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotNull();
    }
}
