using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MaterialsExchangeAPI.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Material> Materials => Set<Material>();
    public DbSet<Seller> Sellers => Set<Seller>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<Material>(x => x.HasKey(m => new { m.Id }));
        builder.Entity<Material>()
            .HasOne(u => u.Seller)
            .WithMany(u => u.Materials)
            .HasForeignKey(u => u.SellerId);

        builder.Entity<Seller>(x => x.HasKey(s => new { s.Id }));
    }
}
