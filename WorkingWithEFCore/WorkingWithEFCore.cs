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
            QueryingCategories();
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
    }
}
