namespace Application.Materials.Commands.CreateMaterial;

public record CreateMaterialResponseDto
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public required decimal Price { get; init; }

    public required int SellerId { get; init; }
}
