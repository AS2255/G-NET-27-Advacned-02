using ShopMaster.Data;
using ShopMaster.Services;

namespace Assignment_02_Adv
{
    internal class Program
    {
        static void Main()
        {
            var products = ProductCatalog.GetProducts();

            Console.WriteLine("=== Task 01: Smart Search ===");

            var electronics = ProductSearchService.SearchProducts(
                products, p => p.Category == "Electronics");

            var cheap = ProductSearchService.SearchProducts(
                products, p => p.Price < 50);

            var inStock = ProductSearchService.SearchProducts(
                products, p => p.Stock > 0);

            var clothing = ProductSearchService.SearchProducts(
                products, p => p.Category == "Clothing" && p.Price < 100);

            PrintList(electronics, "Electronics");
            PrintList(cheap, "Under $50");
            PrintList(inStock, "In Stock");
            PrintList(clothing, "Clothing Under $100");

            Console.WriteLine("\n=== Task 03.1: Reports ===");
            Console.WriteLine();

            // Short Report
            Console.WriteLine("-- Short Report --");
            ReportService.PrintReport(products,
                p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine();

            // Detailed Report
            Console.WriteLine("-- Detailed Report --");
            ReportService.PrintReport(products,
                p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));


            Console.WriteLine("\n=== Task 03.2: Transform ===");
            Console.WriteLine();

            Console.WriteLine("-- Summary List --");
            var summary = ReportService.TransformProducts(products,
                p => $"{p.Name} (${p.Price})");

            foreach (var item in summary)
                Console.WriteLine(item);

            Console.WriteLine();

            Console.WriteLine("-- Price Labels --");
            var labels = ReportService.TransformProducts(products,
                p => new
                {
                    p.Name,
                    Label = p.Price > 100 ? "Expensive!" : "Affordable"
                });

            foreach (var item in labels)
                Console.WriteLine($"{item.Name}: {item.Label}");


            Console.WriteLine("\n=== Task 03.3: Low Stock ===");
            Console.WriteLine();

            Console.WriteLine("-- Low-Stock Alert  --");
            var lowStock = ProductFilterService.FilterProducts(
                products, p => p.Stock < 20);

            foreach (var p in lowStock)
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
        }

        static void PrintList(System.Collections.Generic.List<ShopMaster.Models.Product> list, string title)
        {
            Console.WriteLine($"\n-- {title} --");
            foreach (var p in list)
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock:${p.Stock})");
        }
    }
}
