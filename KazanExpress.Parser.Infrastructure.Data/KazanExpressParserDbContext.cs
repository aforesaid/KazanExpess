using System.Threading.Tasks;
using KazanExpress.Parser.Domain.Entities;
using KazanExpress.Parser.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace KazanExpress.Parser.Infrastructure.Data
{
    public class KazanExpressParserDbContext : DbContext, IKazanExpressParserRepo
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
            modelBuilder.Entity<CategoryEntity>().Property(x => x.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<CategoryEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.ProductAmount);
            modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.Title);
            modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.ProductIds);

            modelBuilder.Entity<ProductEntity>().Property(x => x.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.Rating);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.Title);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.CharityCommission);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.FullPrice);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.SellPrice);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.ROrdersQuantity);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.OrdersQuantity);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.CategoryName);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql( "User ID=postgres;Password=root;Server=localhost;Port=5432;Database=kazan-express-parser;Integrated Security=true;",
                    npgsql => npgsql.MigrationsAssembly("KazanExpress.Parser.Infrastructure.Data"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        public async Task AddOrUpdateProducts(ProductEntity[] products)
        {
            foreach (var productEntity in products)
            {
                var existProduct = await Products.FirstOrDefaultAsync(x => x.Id == productEntity.Id);
                if (existProduct == null)
                {
                    await Products.AddAsync(productEntity);
                }
                else
                {
                    existProduct.UpdateRating(productEntity.Rating);
                    existProduct.UpdateOrdersQuantity(productEntity.OrdersQuantity);
                    existProduct.UpdateSellPrice(productEntity.SellPrice);
                    existProduct.UpdateROrdersQuantity(productEntity.ROrdersQuantity);
                    Products.Update(existProduct);
                }

                await SaveChangesAsync();
            }
        }
    }
}