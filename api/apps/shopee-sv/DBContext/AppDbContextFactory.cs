

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace shopee_sv.DBContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {

            
            /// Build configuration manually
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            string baseString = configuration.GetConnectionString("MariaDb")!;

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            string dbName = "ShopeeDB";

            string conn = $"{baseString};Database={dbName};";

            builder.UseMySql(conn, ServerVersion.AutoDetect(conn));

            return new AppDbContext(builder.Options);
        }
    }
}