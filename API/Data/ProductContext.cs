using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products {get; set;}
    }
}
