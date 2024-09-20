using Microsoft.EntityFrameworkCore;
using Ecommerce_backend.Models;
namespace Ecommerce_backend.Data{

 
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
 
    // Define your DbSets here
    public DbSet<Product> Products { get; set; }
}
}