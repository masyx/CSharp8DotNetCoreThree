using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Northwind _db;

        public HomeController(ILogger<HomeController> logger, Northwind injectedContext)
        {
            _logger = logger;
            _db = injectedContext; 
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                VisitorCount = new Random().Next(1, 1000),
                Categories = _db.Categories.ToList(),
                Products = _db.Products.ToList()
            };
            return View(model);
        }

        // ***MY NOTE*** You can decorate the action method to make the route simpler
        // BEFOR: https://localhost:5001/home/privacy
        [Route("private")]
        // AFTER: https://localhost:5001/private
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ProductDetail(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
            }

            var model = _db.Products.SingleOrDefault(product => product.ProductID == id);

            //if(model is null)
            //{
            //    return NotFound("Couldn't find a product with privided id");
            //}
            //return View(model);

            // more concise way of writing the above code
            return model is not null ? View(model) : NotFound($"Couldn't find a product with privided id of: {id}");
        }

        public IActionResult ModelBinding()
        {
            return View(); // the page with a form to submit
        }

        [HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            //return View(thing); // show the model bound thing

            var model = new HomeModelBindingViewModel
            {
                Thing = thing,
                HasErrors = !ModelState.IsValid,
                ValidationErrors = ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage)
            };

            return View(model);
        }

        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return NotFound("You must pass a product price in the query string, " +
                    "for example, /Home/ProductsThatCostMoreThan?price = 50");
            }

            IEnumerable<Product> model = _db.Products
                .Include(t => t.Category)
                .Include(t => t.Supplier)
                .Where(p => p.UnitPrice > price);

            if (model.Count() == 0)
            {
                return View($"Couldn't find any product with the price more than {price}");
            }

            ViewData["MaxPrice"] = price.Value.ToString("C");
            return View(model);
        }
    }
}
