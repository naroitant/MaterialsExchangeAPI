namespace Application.Materials.Commands.CreateMaterial;

public record CreateMaterialRequestDto
{
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public Guid SellerId { get; init; }
}
