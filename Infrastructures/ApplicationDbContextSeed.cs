using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {

            context.Database.Migrate();

            //Seed
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(GetPreconfiguredCategories());
                await context.SaveChangesAsync();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(GetPreconfiguredProducts());
                await context.SaveChangesAsync();
            }

        }

        //Categories

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category {  Name = "Home"},
                new Category { Name = "Garden"},
                new Category {Name = "Electronics"},
                new Category { Name = "Fitness"},
                new Category { Name = "Toys"}

            };
        }


        //Products
        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product { Name = "Table",Description="Dining Table",Price=123.90M,CategoryId =1 },
                new Product { Name = "Chair",Description="For home use",Price=100M,CategoryId =1 },
                new Product { Name = "Flower Pot",Description="For Garden",Price=10M,CategoryId =2 },
                new Product { Name = "Computer",Description="Desktop",Price=500M,CategoryId =3 },
                new Product { Name = "Cycle",Description="For workout",Price=50M,CategoryId =4 },
                new Product { Name = "Ball",Description="To play football",Price=5M,CategoryId =5 },
            };
        }


    }
}
