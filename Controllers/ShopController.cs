// Controllers/ShopController.cs
using Microsoft.AspNetCore.Mvc;

public class ShopController : Controller
{
    // Conventional route will hit this via Program.cs ("shop/list")
    [HttpGet]
    public IActionResult List()
    {
        // placeholder sample data for Iteration 3
        ViewData["Products"] = new[] { "Coffee", "Tea", "Milk" };
        return View();
    }

    // Attribute route -> "/shop/details/5" (int only)
    [HttpGet("shop/details/{id:int}")]
    public IActionResult Details(int id)
    {
        ViewData["ProductId"] = id;
        return View();
    }

    // Optional: we'll use this in Iteration 4 (form + validation)
    [HttpGet]
    public IActionResult Add() => View();
}
