using System.Diagnostics;
using IS4439_Project_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS4439_Project_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

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
