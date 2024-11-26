namespace Application.Sellers.Commands.CreateSeller;

public record CreateSellerCommand(CreateSellerRequestDto Dto)
    : IRequest<CreateSellerResponseDto?>;