using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers
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

        [HttpPost]
        public IActionResult SetName(string name)
        {
            HttpContext.Session.SetString("Name", name);
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            string LocalVariable = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
            {
                return RedirectToAction("Index");
            }
            int number = 22;
            ViewData["Number"] = number;
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string operation)
        {
            int number = (int)HttpContext.Session.GetInt32("Number") ?? 22;
            switch (operation)
            {
                case "+1":
                    return RedirectToAction("Increment", new { number });
                case "-1":
                    return RedirectToAction("Decrement", new { number });
                case "x2":
                    return RedirectToAction("MultiplyBy2", new { number });
                case "random":
                    return RedirectToAction("AddRandom", new { number });
                default:
                    return RedirectToAction("Dashboard");
            }
        }

        public IActionResult Increment(int number)
        {
            return RedirectToAction("Dashboard", new { number = number + 1 });
        }

        public IActionResult Decrement(int number)
        {
            return RedirectToAction("Dashboard", new { number = number - 1 });
        }

        public IActionResult MultiplyBy2(int number)
        {
            return RedirectToAction("Dashboard", new { number = number * 2 });
        }

        public IActionResult AddRandom(int number)
        {
            Random rand = new Random();
            number += rand.Next(1, 11);
            return RedirectToAction("Dashboard", new { number });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
