namespace MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;

public record CreateSellerRequestDto
{
    public string Name { get; init; } = string.Empty;
}
