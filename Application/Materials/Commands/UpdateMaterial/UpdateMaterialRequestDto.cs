namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;

public record UpdateMaterialRequestDto
{
    public int Id;
    public string Name = string.Empty;
    public decimal Price;
    public int SellerId;
}
