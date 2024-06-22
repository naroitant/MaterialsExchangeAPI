namespace MaterialsExchangeAPI.Application.Sellers.Commands.DeleteSeller;

public record DeleteSellerResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
