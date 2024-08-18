namespace Application.Sellers.Queries.GetSellerById;

public record GetSellerByIdRequestDto
{
    public required int Id { get; init; }
}
