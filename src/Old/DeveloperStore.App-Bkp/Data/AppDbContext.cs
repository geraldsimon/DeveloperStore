using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DeveloperStore.App.Models;

namespace DeveloperStore.App.Data
{
    public class AppDbContext : IdentityDbContext<Seller>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Garantir que Id do Seller seja uniqueidentifier
            builder.Entity<Seller>()
                .Property(s => s.Id)
                .HasColumnType("uniqueidentifier");  // Garantindo que Seller.Id seja uniqueidentifier

            // Garantir que SellerId no Product seja uniqueidentifier
            builder.Entity<Product>()
                .Property(p => p.SellerId)
                .HasColumnType("uniqueidentifier");  // Garantindo que Product.SellerId seja uniqueidentifier

            // Configuração da chave estrangeira entre Seller e Product
            builder.Entity<Product>()
                .HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração da chave estrangeira entre Product e Category
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
