namespace EventLibrary;

public sealed class SynchronizeSellersEvent
{
    public IEnumerable<SynchronizedSellerDto> Sellers { get; set; } = [];

    public sealed class SynchronizedSellerDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
    }
}