using System;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace WorkingWithEFCore
{
    class WorkingWithEFCore
    {
        static void Main(string[] args)
        {
            //QueryingCategories();
            FilteredIncludes(100);
            //QueryingProducts();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                Console.WriteLine("Categories and how many products they have.");

                // a query to get categories and they related products
                IQueryable<Category> cats = db.Categories.Include(cat => cat.Products);

                foreach(var cat in cats)
                {
                    Console.WriteLine($" Category '{cat.CategoryName}' has {cat.Products.Count} products");
                }
            }
        }

        /// <summary>
        /// Filters by min units in stock
        /// </summary>
        /// <param name="minUnitsInStock">Minimum value for units in stock</param>
        /// <returns>Nothing</returns>
        static void FilteredIncludes(int minUnitsInStock)
        {
            using(var db = new Northwind())
            {
                //a query for categories that have products with that minimum number of units in stock.
                var cats = db.Categories.Include(category => category.Products.Where(p => p.Stock >= minUnitsInStock));

                foreach (var cat in cats)
                {
                    Console.WriteLine($"{cat.CategoryName} has {cat.Products.Count} products with " +
                        $"minimum of {minUnitsInStock} units in stock");

                    foreach (var p in cat.Products)
                    {
                        Console.WriteLine($"{p.ProductName} has {p.Stock} units in stock.");
                    }

                }

                Console.WriteLine($"ToQueryString: {cats.ToQueryString()}");
            }
        }

        /// <summary>
        /// Query for products that cost more than the price
        /// </summary>
        static void QueryingProducts()
        {
            Console.WriteLine("Products that cost more than a price, highest at the top");

            string input;
            decimal minPrice;

            do
            {
                Console.WriteLine("Enter the min price to filter products:");
                input = Console.ReadLine();
            }
            while (!decimal.TryParse(input, out minPrice));

            using(var db = new Northwind())
            {
                IQueryable<Product> products = db.Products.Where(p => p.Cost > minPrice)
                    .OrderByDescending(p => p.Cost);

                Console.WriteLine($"There are {products.Count()} products with the min price of {minPrice:C}:");

                foreach (Product product in products)
                {
                    Console.WriteLine($"{product.ProductID}: {product.ProductName} costs {product.Cost:C2} " +
                        $"and has {product.Stock} in stock");
                }

                Console.WriteLine($"ToQueryString: {products.ToQueryString()}");
            }
        }
    }
}
