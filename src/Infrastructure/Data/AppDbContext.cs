using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options), IAppDbContext
{
    public DbSet<Material> Materials => Set<Material>();

    public DbSet<Seller> Sellers => Set<Seller>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());

        builder
            .Entity<Material>()
            .HasOne(e => e.Seller)
            .WithMany(e => e.Materials)
            .HasForeignKey(e => e.SellerId);
    }
}
