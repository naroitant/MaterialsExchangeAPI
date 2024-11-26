namespace Application.Sellers.Commands.SynchronizeSellers;

public record SynchronizeSellersCommand(SynchronizeSellersRequestDto Dto)
    : IRequest;