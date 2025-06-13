using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DBContext
{
    public class SimpleShopDbContext : DbContext
    {
        public SimpleShopDbContext(DbContextOptions<SimpleShopDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations
            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(i => i.UnitPrice)
                .HasPrecision(18, 2);
        }

    }
}
