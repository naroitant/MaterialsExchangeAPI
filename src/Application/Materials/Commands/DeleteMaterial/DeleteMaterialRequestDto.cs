namespace Application.Materials.Commands.DeleteMaterial;

public record DeleteMaterialRequestDto
{
    public Guid Id { get; init; }
}
