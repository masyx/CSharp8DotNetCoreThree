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
            FilterAndSort();
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
    }
}
