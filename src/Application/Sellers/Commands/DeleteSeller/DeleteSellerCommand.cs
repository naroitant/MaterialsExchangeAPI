namespace Application.Sellers.Commands.DeleteSeller;

public record DeleteSellerCommand(int id) : IRequest<bool>
{
    public int Id { get; init; } = id;
}