namespace Application.Materials.Queries;

public record GetMaterialResponseDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required int SellerId { get; init; }
}
