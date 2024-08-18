namespace Application.Sellers.Commands.CreateSeller;

public record CreateSellerResponseDto
{
    public required int Id { get; init; }

    public required string Name { get; init; }
}
