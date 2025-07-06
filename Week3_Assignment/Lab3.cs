using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RetailInventoryContextApp
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }

    public class RetailInventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Add your LocalDB v11.0 connection string here
            optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=RetailInventoryDb;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Retail Inventory System");

            using (var context = new RetailInventoryContext())
            {
                context.Database.EnsureCreated();
                Console.WriteLine("Connected to the database successfully.");
            }
        }
    }
}
