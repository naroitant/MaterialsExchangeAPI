namespace MaterialsExchangeAPI.Application.Materials.Queries;

public record GetMaterialResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int SellerId { get; set; }
}
