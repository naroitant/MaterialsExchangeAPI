using EventLibrary;

namespace Application.Sellers.Commands.SynchronizeSellers;

public sealed class SynchronizeSellersRequestDto
{
    public required IEnumerable<SynchronizeSellersEvent.SynchronizedSellerDto> Sellers = [];
}
