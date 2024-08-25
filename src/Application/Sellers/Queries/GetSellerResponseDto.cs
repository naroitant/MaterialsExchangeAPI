using Application.Materials.Queries;

namespace Application.Sellers.Queries;

public record GetSellerResponseDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
}
