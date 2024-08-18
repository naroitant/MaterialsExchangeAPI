namespace Application.Sellers.Commands.CreateSeller;

public record CreateSellerCommand(CreateSellerRequestDto dto)
    : IRequest<CreateSellerResponseDto?>
{
    public required CreateSellerRequestDto Dto { get; init; } = dto;
}