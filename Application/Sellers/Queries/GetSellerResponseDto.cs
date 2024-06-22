namespace MaterialsExchangeAPI.Application.Sellers.Queries;

public record GetSellerResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
