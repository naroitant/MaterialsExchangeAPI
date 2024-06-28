namespace MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;

public record CreateSellerResponseDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;
}
