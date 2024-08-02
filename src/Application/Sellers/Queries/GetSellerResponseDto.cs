namespace Application.Sellers.Queries;

public record GetSellerResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
}
