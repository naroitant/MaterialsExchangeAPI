namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterialPrices;

public record UpdateMaterialPriceResponseDto
{
    public int Id;
    public string Name = string.Empty;
    public decimal Price;
    public int SellerId;
}
