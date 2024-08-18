namespace Application.Materials.Commands.DeleteMaterial;

public record DeleteMaterialRequestDto
{
    public required int Id { get; init; }
}
