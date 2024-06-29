namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;

public record UpdateMaterialRequestDto
{
    public int Id { get; set; }

    public string Name { get; init; } = string.Empty;

    public decimal Price { get; set; }

    public int SellerId { get; set; }
}
