namespace MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;

public record CreateSellerResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
