namespace Application.Materials.Commands.UpdateMaterial;

public record UpdateMaterialRequestDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public int SellerId { get; init; }
}
