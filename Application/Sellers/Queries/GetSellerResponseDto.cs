namespace MaterialsExchangeAPI.Application.Sellers.Queries;

public record GetSellerResponseDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;
}
