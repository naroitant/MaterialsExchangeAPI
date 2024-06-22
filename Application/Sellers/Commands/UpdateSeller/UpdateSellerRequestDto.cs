namespace MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;

public record UpdateSellerRequestDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
