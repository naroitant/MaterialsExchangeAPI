namespace Application.Sellers.Commands.CreateSeller;

public record CreateSellerRequestDto
{
    public required string Name { get; init; }
}
