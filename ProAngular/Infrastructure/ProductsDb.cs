using System.Data.Entity;
using ProAngular.Models;

namespace ProAngular.Infrastructure
{
    public class ProductsDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}