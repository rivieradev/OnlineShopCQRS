using Microsoft.EntityFrameworkCore;
using OnlineShopCQRS.Domain;

namespace OnlineShopCQRS.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}
