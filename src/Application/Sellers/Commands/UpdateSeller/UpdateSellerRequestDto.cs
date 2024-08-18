namespace Application.Sellers.Commands.UpdateSeller;

public record UpdateSellerRequestDto
{
    public required int Id { get; init; }

    public required string Name { get; init; } = string.Empty;
}
