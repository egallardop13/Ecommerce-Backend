using Microsoft.EntityFrameworkCore;
using Ecommerce_backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce_backend.Data{

 
public class AppDbContext : DbContext
{
        private readonly IConfiguration _config;     
    public AppDbContext(IConfiguration config) 
    {
        _config = config;
    }
 
    // Define your DbSets here
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
        optionsBuilder => optionsBuilder.EnableRetryOnFailure());
    }
}
}