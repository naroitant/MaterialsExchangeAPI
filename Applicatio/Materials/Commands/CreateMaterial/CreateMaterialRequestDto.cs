namespace MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;

public record CreateMaterialRequestDto
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int SellerId { get; set; }
}
