namespace Application.Sellers.Commands.UpdateSeller;

public record UpdateSellerResponseDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}
