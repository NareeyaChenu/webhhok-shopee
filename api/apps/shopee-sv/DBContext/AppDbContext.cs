

using Microsoft.EntityFrameworkCore;
using ShopeeLib.Models;

namespace shopee_sv.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }
    }
}