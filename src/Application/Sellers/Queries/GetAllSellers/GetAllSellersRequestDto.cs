namespace Application.Sellers.Queries.GetAllSellers;

public record GetAllSellersRequestDto
{
    public required int Skip { get; init; }

    public required int Take { get; init; }
}
