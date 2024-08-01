namespace Application.Sellers.Queries.GetSellerById;

public record GetSellerByIdRequestDto
{
    public Guid Id { get; init; }
}
