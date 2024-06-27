namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;

public record UpdateMaterialResponseDto
{
    public int Id;
    public string Name = string.Empty;
    public decimal Price;
    public int SellerId;
}
