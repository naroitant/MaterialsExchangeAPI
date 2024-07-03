namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;

public record UpdateMaterialRequestDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }

    public int SellerId { get; init; }
}
