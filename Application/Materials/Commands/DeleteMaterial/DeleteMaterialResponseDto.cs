namespace MaterialsExchangeAPI.Application.Materials.Commands.DeleteMaterial;

public record DeleteMaterialResponseDto
{
    public int Id;
    public string Name = string.Empty;
    public decimal Price;
    public int SellerId;
}
