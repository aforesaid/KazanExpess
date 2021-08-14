using Microsoft.EntityFrameworkCore;

namespace KazanExpress.Parser.Infrastructure.Data.PostgreSql
{
    public class KazanExpressParserDbContextPostgreSql : KazanExpressParserDbContext
    {
        public KazanExpressParserDbContextPostgreSql()
        { }

        public KazanExpressParserDbContextPostgreSql(DbContextOptions<KazanExpressParserDbContextPostgreSql> options) 
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql( "User ID=postgres;Password=root;Server=localhost;Port=5432;Database=kazan-express-parser;Integrated Security=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }
        
    }
}