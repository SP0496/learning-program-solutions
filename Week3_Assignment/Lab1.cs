using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

#region Models

public class ProductCategory
{
    public int ProductCategoryId { get; set; }
    public string Title { get; set; } = "";
    public List<InventoryItem> Items { get; set; } = new();
}

public class InventoryItem
{
    public int InventoryItemId { get; set; }
    public string Name { get; set; } = "";
    public string CategoryLabel { get; set; } = "";
}

#endregion

#region Database Context

public class ShopInventoryContext : DbContext
{
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();

    protected override void OnConfiguring(DbContextOptionsBuilder configBuilder)
    {
        // Using SQLite to store inventory data in a local file
        configBuilder.UseSqlite("Data Source=SmartStoreInventory.db");
    }
}

#endregion

#region App Entry Point

public class StoreInventoryConsoleApp
{
    public static void Main()
    {
        using var dbContext = new ShopInventoryContext();
        dbContext.Database.EnsureCreated(); // Creates the SQLite database if not present

        // Seed data only if database is empty
        if (!dbContext.ProductCategories.Any())
        {
            var gadgetsCategory = new ProductCategory { Title = "Gadgets" };

            dbContext.ProductCategories.Add(gadgetsCategory);

            dbContext.InventoryItems.AddRange(
                new InventoryItem { Name = "Smartphone", CategoryLabel = "Gadgets" },
                new InventoryItem { Name = "Wireless Earbuds", CategoryLabel = "Gadgets" }
            );

            dbContext.SaveChanges();
        }

        // Display current inventory
        Console.WriteLine("Inventory List:");
        foreach (var item in dbContext.InventoryItems)
        {
            Console.WriteLine($"- {item.Name} [{item.CategoryLabel}]");
        }
    }
}

#endregion
