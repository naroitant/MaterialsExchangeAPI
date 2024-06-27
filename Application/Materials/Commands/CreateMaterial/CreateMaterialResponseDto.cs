namespace MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;

public record CreateMaterialResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int SellerId { get; set; }
}
