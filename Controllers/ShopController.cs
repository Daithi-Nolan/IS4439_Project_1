using Microsoft.AspNetCore.Mvc;
using IS4439_Project_1.Models; // Make sure the namespace matches your project (adjust if needed)
using System.Collections.Generic;
using System.Linq;

namespace IS4439_Project_1.Controllers
{
    public class ShopController : Controller
    {
        // Sample in-memory product list for display
        private static List<Product> SampleProducts => new()
        {
            new() { Id = 1, Name = "Coffee", Price = 3.50m, InStock = true },
            new() { Id = 2, Name = "Tea",    Price = 2.80m, InStock = true },
            new() { Id = 3, Name = "Milk",   Price = 1.20m, InStock = false },
            new() { Id = 4, Name = "Sugar",  Price = 1.00m, InStock = true },
        };

        // Conventional route → /shop/list  (defined in Program.cs)
        [HttpGet]
        public IActionResult List()
        {
            // Pass the product list to the view
            return View(SampleProducts);
        }

        // Attribute route → /shop/details/{id:int}
        [HttpGet("shop/details/{id:int}")]
        public IActionResult Details(int id)
        {
            var product = SampleProducts.FirstOrDefault(p => p.Id == id);
            if (product is null)
            {
                // Graceful 404 handling if the ID isn’t found
                return NotFound();
            }

            return View(product);
        }

        // Placeholder for the Add form (Iteration 4)
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
