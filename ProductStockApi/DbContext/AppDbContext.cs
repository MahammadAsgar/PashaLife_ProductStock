using Microsoft.EntityFrameworkCore;
using ProductStockApi.Data.Model;

namespace ProductStockApi.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
    }
}
