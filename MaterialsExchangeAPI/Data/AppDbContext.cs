using MaterialsExchangeAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaterialsExchangeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Material>(x => x.HasKey(m => new { m.Id }));

            builder.Entity<Material>()
                .HasOne(u => u.Seller)
                .WithMany(u => u.Materials)
                .HasForeignKey(u => u.SellerId);

            builder.Entity<Seller>(x => x.HasKey(s => new { s.Id }));
        }
    }
}
