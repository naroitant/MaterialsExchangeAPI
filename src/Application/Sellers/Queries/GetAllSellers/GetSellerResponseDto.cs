namespace Application.Sellers.Queries.GetAllSellers;

public record GetAllSellersResponseDto
{
    public required List<GetSellerResponseDto> Dtos { get; init; } = [];
}
