using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqWithEFCore
{
    class LinqWithEFCoreClass
    {
        static void Main(string[] args)
        {
            //FilterAndSort();
            //GroupJoinCategoriesAndProducts();
            AggregateProducts();
        }

        // products that cost less than 10
        static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var products = db.Products.Where(product => product.UnitPrice < 10M)
                    .OrderByDescending(product => product.UnitPrice)
                    .Select(product => new
                    {
                        product.ProductID,
                        product.ProductName,
                        product.UnitPrice
                    });

                WriteLine("Products that cost less than $10:");
                foreach (var item in products)
                {
                    WriteLine("{0}: {1} costs {2:$#,##0.00}",
                      item.ProductID, item.ProductName, item.UnitPrice);
                }
                WriteLine();
            }

        }

        static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                // group all products by their category to return 8 matches
                var queryGroup = db.Categories.AsEnumerable().GroupJoin(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, matchingProducts) => new
                    {
                        c.CategoryName,
                        Products = matchingProducts.OrderBy(p => p.ProductName)
                    });

                foreach (var item in queryGroup)
                {
                    WriteLine("{0} has {1} products.",
                        arg0: item.CategoryName,
                        arg1: item.Products.Count());
                    foreach (var product in item.Products)
                    {
                        WriteLine($" {product.ProductName}");
                    }
                }
            }
        }

        static void AggregateProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-25} {1,10}",
                  arg0: "Product count:",
                  arg1: db.Products.Count());
                WriteLine("{0,-25} {1,10:$#,##0.00}",
                  arg0: "Highest product price:",
                  arg1: db.Products.Max(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:N0}",
                  arg0: "Sum of units in stock:",
                  arg1: db.Products.Sum(p => p.UnitsInStock));
                WriteLine("{0,-25} {1,10:N0}",
                  arg0: "Sum of units on order:",
                  arg1: db.Products.Sum(p => p.UnitsOnOrder));
                WriteLine("{0,-25} {1,10:$#,##0.00}",
                  arg0: "Average unit price:",
                  arg1: db.Products.Average(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:$#,##0.00}",
                  arg0: "Value of units in stock:",
                  arg1: db.Products.AsEnumerable()
                    .Sum(p => p.UnitsInStock * p.UnitPrice));
            }
        }
    }
}
