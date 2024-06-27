namespace MaterialsExchangeAPI.Application.Materials.Queries;

public record GetMaterialResponseDto
{
    public int Id;
    public string Name = string.Empty;
    public decimal Price;
    public int SellerId;
}
