using ProAngular.Models;

namespace ProAngular.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProAngular.Infrastructure.ProductsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProAngular.Infrastructure.ProductsDb context)
        {
            context.Products.AddOrUpdate(p => p.Name,
                new Product { Name = "Kayak", Description = "A boat for one person", Category = "Watersports", Price = 275 },
                new Product { Name = "LifeJacket", Description = "Protective and fashionable", Category = "Watersports", Price = 48.95m },
                new Product { Name = "Soccer Ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.5m },
                new Product { Name = "Corner Flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 34.95m },
                new Product { Name = "Stadium", Description = "Flat-packed 35,000 seat-stadium", Category = "Soccer", Price = 79500m },
                new Product { Name = "Thinking Cap", Description = "Improve your brain efficiency by 75%", Category = "Chess", Price = 16 },
                new Product { Name = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", Category = "Chess", Price = 29.95m },
                new Product { Name = "Human Chess Board", Description = "A fun game for the family", Category = "Chess", Price = 75 },
                new Product { Name = "Bling-Bling King", Description = "Gold-plated, diamon-studded king", Category = "Chess", Price = 1200 }
                );
        }
    }
}
