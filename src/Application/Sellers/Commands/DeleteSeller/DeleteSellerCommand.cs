namespace Application.Sellers.Commands.DeleteSeller;

public record DeleteSellerCommand(DeleteSellerRequestDto dto) : IRequest<bool>
{
    public DeleteSellerRequestDto Dto { get; init; } = dto;
}