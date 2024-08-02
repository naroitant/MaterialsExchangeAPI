namespace Application.Materials.Commands.CreateMaterial;

public record CreateMaterialResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public Guid SellerId { get; init; }
}
