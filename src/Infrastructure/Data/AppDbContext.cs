using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

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

        builder
            .Entity<Seller>(e => e.HasKey(s => new { s.Id }));
    }
}
