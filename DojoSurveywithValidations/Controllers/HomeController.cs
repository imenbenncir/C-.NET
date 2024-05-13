using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveywithValidations.Models;

namespace DojoSurveywithValidations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static User? user;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult Process(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", newUser);
            }
            
            // Assign the submitted user data to the user variable
            user = newUser;
            
            // Redirect to the Results action
            return RedirectToAction("Results");
        }

        [HttpGet("results")]
        public IActionResult Results()
        {
            // Check if user data is available
            if (user != null)
            {
                // Pass the user data to the Results view
                return View(user);
            }
            else
            {
                // If user data is not available, redirect to the Index action
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
