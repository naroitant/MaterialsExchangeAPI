namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterialPrices;

public record UpdateMaterialPriceResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int SellerId { get; set; }
}
