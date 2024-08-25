namespace Application.Materials.Commands.DeleteMaterial;

public class DeleteMaterialCommandValidator
    : AbstractValidator<DeleteMaterialCommand>
{
    public DeleteMaterialCommandValidator()
    {
        RuleFor(c => c.Dto.Id)
            .NotNull();
    }
}
