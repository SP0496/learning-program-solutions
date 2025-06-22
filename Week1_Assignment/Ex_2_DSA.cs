using System;
using System.Linq;

namespace ECommerceSearchApp
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public Item(int id, string title, string category)
        {
            Id = id;
            Title = title;
            Category = category;
        }
    }

    public class SearchEngine
    {
        // Linear search
        public static Item? FindItemByNameLinear(Item[] catalog, string searchTitle)
        {
            foreach (var item in catalog)
            {
                if (item.Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        // Binary search (requires sorted input)
        public static Item? FindItemByNameBinary(Item[] sortedCatalog, string searchTitle)
        {
            int low = 0;
            int high = sortedCatalog.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int result = string.Compare(sortedCatalog[mid].Title, searchTitle, true);

                if (result == 0)
                    return sortedCatalog[mid];
                else if (result < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return null;
        }
    }

    class EntryPoint
    {
        static void Main(string[] args)
        {
            Item[] catalog = new Item[]
            {
                new Item(101, "Headphones", "Electronics"),
                new Item(102, "Backpack", "Accessories"),
                new Item(103, "Sneakers", "Footwear"),
                new Item(104, "Smartphone", "Electronics")
            };

            Console.WriteLine("Linear Search:");
            Item? linearResult = SearchEngine.FindItemByNameLinear(catalog, "Sneakers");

            if (linearResult != null)
                Console.WriteLine($"Found: {linearResult.Title} in {linearResult.Category}");
            else
                Console.WriteLine("Item not found.");

            var sortedCatalog = catalog.OrderBy(item => item.Title).ToArray();

            Console.WriteLine("\nBinary Search:");
            Item? binaryResult = SearchEngine.FindItemByNameBinary(sortedCatalog, "Sneakers");

            if (binaryResult != null)
                Console.WriteLine($"Found: {binaryResult.Title} in {binaryResult.Category}");
            else
                Console.WriteLine("Item not found.");
        }
    }
}
