namespace MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;

public record CreateSellerRequestDto
{
    public string Name { get; set; } = string.Empty;
}
