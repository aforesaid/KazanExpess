using KazanExpress.Parser.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KazanExpress.Parser.Infrastructure.Data
{
    public class KazanExpressParserDbContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; protected set; }
        public DbSet<ProductEntity> Products { get; protected set; }
        public KazanExpressParserDbContext() 
            : base()
        { }

        public KazanExpressParserDbContext(DbContextOptions options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.ProductAmount);
            modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.Title);
            modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.ProductIds);

            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.Rating);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.Title);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.CharityCommission);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.FullPrice);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.SellPrice);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.ROrdersQuantity);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.OrdersQuantity);

            base.OnModelCreating(modelBuilder);
        }
    }
}