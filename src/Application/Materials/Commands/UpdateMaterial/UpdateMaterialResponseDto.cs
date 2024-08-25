namespace Application.Materials.Commands.UpdateMaterial;

public record UpdateMaterialResponseDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required int SellerId { get; init; }
}
