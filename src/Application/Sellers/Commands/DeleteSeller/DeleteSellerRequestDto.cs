namespace Application.Sellers.Commands.DeleteSeller;

public record DeleteSellerRequestDto
{
    public Guid Id { get; init; }
}
