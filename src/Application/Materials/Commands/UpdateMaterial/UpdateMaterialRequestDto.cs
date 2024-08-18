namespace Application.Materials.Commands.UpdateMaterial;

public record UpdateMaterialRequestDto
{
    public required string Name { get; init; }

    public required decimal Price { get; init; }

    public required int SellerId { get; init; }
}
