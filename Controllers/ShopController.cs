using Microsoft.AspNetCore.Mvc;
using IS4439_Project_1.Models;
using System.Collections.Generic;
using System.Linq;

namespace IS4439_Project_1.Controllers
{
    public class ShopController : Controller
    {
        // Simple in-memory store for demo (persists while app runs)
        private static readonly List<Product> Products = new()
        {
            new() { Id = 1, Name = "Coffee", Price = 3.50m, InStock = true },
            new() { Id = 2, Name = "Tea",    Price = 2.80m, InStock = true },
            new() { Id = 3, Name = "Milk",   Price = 1.20m, InStock = false },
            new() { Id = 4, Name = "Sugar",  Price = 1.00m, InStock = true },
        };

        // Conventional route → /shop/list (Program.cs)
        [HttpGet]
        public IActionResult List()
        {
            // Optional: show success message if present
            ViewBag.Message = TempData["Message"] as string;
            return View(Products);
        }

        // Attribute route → /shop/details/{id:int}
        [HttpGet("shop/details/{id:int}")]
        public IActionResult Details(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            return View(product);
        }

        // GET: show empty form
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Product());
        }

        // POST: bind form -> validate -> add -> redirect
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Product model)
        {
            if (!ModelState.IsValid)
            {
                // Re-render the form with validation errors
                return View(model);
            }

            // Simulate identity / key
            model.Id = (Products.Count == 0) ? 1 : Products.Max(p => p.Id) + 1;
            Products.Add(model);

            // Show confirmation via TempData, then redirect to Details (or List)
            TempData["Message"] = $"Product \"{model.Name}\" added successfully.";
            return RedirectToAction(nameof(Details), new { id = model.Id });
        }
    }
}
