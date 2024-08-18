namespace Application.Sellers.Commands.UpdateSeller;

public record UpdateSellerRequestDto
{
    public required string Name { get; init; } = string.Empty;
}
