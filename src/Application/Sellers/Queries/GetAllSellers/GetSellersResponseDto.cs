namespace Application.Sellers.Queries.GetAllSellers;

public record GetSellersResponseDto
{
    public required List<GetSellerResponseDto> Dtos { get; init; } = [];
}
