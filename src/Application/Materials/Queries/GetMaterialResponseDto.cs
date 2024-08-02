namespace Application.Materials.Queries;

public record GetMaterialResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public Guid SellerId { get; init; }
}
