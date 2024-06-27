namespace MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;

public record CreateMaterialRequestDto
{
    public string Name = string.Empty;
    public decimal Price;
    public int SellerId;
}
