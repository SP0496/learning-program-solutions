using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UniqueStoreApp
{
    // Category model with nullable properties
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }  // Made nullable to avoid CS8618
        public List<Product>? Products { get; set; }  // Made nullable
    }

    // Product model with nullable properties
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }  // Made nullable
        public decimal Price { get; set; }
        public Category? Category { get; set; }  // Made nullable
    }

    // Database context class
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use LocalDB connection string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=UniqueStoreDB;Trusted_Connection=True;");
        }
    }

    // Main application class
    class Program
    {
        static async Task Main(string[] args)
        {
            using var dbContext = new AppDbContext();

            // Create DB if not already created
            await dbContext.Database.EnsureCreatedAsync();

            // Create categories
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };
            await dbContext.Categories.AddRangeAsync(electronics, groceries);

            // Create products
            var laptop = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var riceBag = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
            await dbContext.Products.AddRangeAsync(laptop, riceBag);

            // Save changes
            await dbContext.SaveChangesAsync();

            Console.WriteLine(" Data inserted into UniqueStoreDB successfully!");

            // Print inserted data
            var categories = await dbContext.Categories.Include(c => c.Products).ToListAsync();
            Console.WriteLine("\n Listing All Categories and Products:\n");

            foreach (var category in categories)
            {
                Console.WriteLine($" Category: {category.Name}");
                if (category.Products != null)
                {
                    foreach (var product in category.Products)
                    {
                        Console.WriteLine($" Product: {product.Name}, Price: ₹{product.Price}");
                    }
                }
            }
        }
    }
}
