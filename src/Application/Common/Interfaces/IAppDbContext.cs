using MaterialsExchangeAPI.Domain.Entities;

namespace MaterialsExchangeAPI.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Material> Materials { get; }

    DbSet<Seller> Sellers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
