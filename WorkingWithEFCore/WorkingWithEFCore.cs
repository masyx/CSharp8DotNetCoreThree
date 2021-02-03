using System;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;



namespace WorkingWithEFCore
{
    class WorkingWithEFCore
    {
        static void Main(string[] args)
        {
            //QueryingCategories();
            //FilteredIncludes(100);
            //QueryingProducts();
            //QueryingWithLike();

            if (AddProduct(categoryID: 6, "Bob's Burger", price: 12))
            {
                Console.WriteLine("Add product successful.");
            }

            //if (IncreaseProductPrice("Bob", 34M))
            //{
            //    Console.WriteLine("Price updated successfully.");
            //}

            //ListProducts();

            int deletedProductsCount = DeleteProducts("Bob");
            Console.WriteLine($"{deletedProductsCount} deleted from database.");
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Console.WriteLine("Categories and how many products they have.");

                // a query to get categories and they related products
                IQueryable<Category> cats = db.Categories.Include(cat => cat.Products);

                foreach (var cat in cats)
                {
                    Console.WriteLine($"Category '{cat.CategoryName}' has {cat.Products.Count} products");
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
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

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


        static void QueryingWithLike()
        {
            using(var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Console.Write("Enter part of the product name: ");
                string input = Console.ReadLine();

                IQueryable<Product> products = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

                foreach (var item in products)
                {
                    Console.WriteLine("{0} has {1} units in stock. Discontinued? {2}",
                        item.ProductName, item.Stock, item.Discontinued);
                }
            }
        }

        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using(var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };

                // mark product as added in change tracking
                db.Products.Add(newProduct);

                // save tracked change to database
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static bool IncreaseProductPrice(string name, decimal newPrice)
        {
            using(var db = new Northwind())
            {
                // get first product whose name starts with name
                var productToUpdate = db.Products.First(p => p.ProductName.StartsWith(name));

                productToUpdate.Cost = newPrice;

                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static int DeleteProducts(string name)
        {
            using(var db = new Northwind())
            {
                IQueryable<Product> productsToDelete = db.Products.Where(p => p.ProductName.StartsWith(name));

                db.Products.RemoveRange(productsToDelete);

                int affected = db.SaveChanges();
                return affected;
            }
        }

        static void ListProducts()
        {
            
            using (var db = new Northwind())
            {
                
                Console.WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}",
                  "ID", "Product Name", "Cost", "Stock", "Disc.");
                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    Console.WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                      item.ProductID, item.ProductName, item.Cost,
                      item.Stock, item.Discontinued);
                }
            }
        }
    }
}
