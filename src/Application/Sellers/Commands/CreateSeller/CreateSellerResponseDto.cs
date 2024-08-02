namespace Application.Sellers.Commands.CreateSeller;

public record CreateSellerResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
}
