using Core.Enum;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка начального заполнения данных
            modelBuilder.Entity<Coin>().HasData(
                new Coin { Id = 1, Denomination = CoinDenomination.One, Count = 0 },
                new Coin { Id = 2, Denomination = CoinDenomination.Two, Count = 0 },
                new Coin { Id = 3, Denomination = CoinDenomination.Five, Count = 0 },
                new Coin { Id = 4, Denomination = CoinDenomination.Ten, Count = 0 }
            );

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems) 
                .HasForeignKey(oi => oi.ProductId) 
                .OnDelete(DeleteBehavior.Restrict); // при удалении Product, связанные (OrderItem) НЕ будут удалены, и выбросится исключение.

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // при удалении Order, связанные OrderItems также будут удалены.

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict); // при удалении Brand, связанные продукты (Product) НЕ будут удалены, и выбросится исключение.
        }
    }
}
