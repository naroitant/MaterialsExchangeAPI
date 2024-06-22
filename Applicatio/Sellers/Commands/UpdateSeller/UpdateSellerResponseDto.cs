namespace MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;

public record UpdateSellerResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
