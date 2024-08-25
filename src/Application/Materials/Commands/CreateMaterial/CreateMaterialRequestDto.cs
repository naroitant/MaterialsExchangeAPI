namespace Application.Materials.Commands.CreateMaterial;

public record CreateMaterialRequestDto
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required int SellerId { get; init; }
}
