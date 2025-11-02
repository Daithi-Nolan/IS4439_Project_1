using System.Diagnostics;
using IS4439_Project_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS4439_Project_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor for the HomeController
        // Enables app to use logging if required
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Loads the main home page
        public IActionResult Index()
        {
            return View();
        }

        // Shows the About page that explains what MiniMart can do
        public IActionResult About()
        {
            return View();
        }

        // Displays the Privacy page (standard page from the template)
        public IActionResult Privacy()
        {
            return View();
        }

        // Handles website errors and shows friendly messages
        [Route("error/{statusCode:int}")]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                // Use a custom 404 view
                Response.StatusCode = 404;
                return View("NotFound404");
            }

            // Generic fallback for other codes (optional)
            ViewBag.StatusCode = statusCode;
            Response.StatusCode = statusCode;
            return View("GenericError");
        }

    }
}
