using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsDishes.Models;

namespace ChefsDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;


    public HomeController(ILogger<HomeController> logger , MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(c=>c.Dishes).ToList();
        return View(AllChefs);
    }
    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View();
    }
    [HttpPost("chefs/new")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else {
            return View("NewChef");
        }
    }
    // Display action
    [HttpGet("Dishes/new")]
    public IActionResult NewDish()
    {
        List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = AllChefs;
        return View();
    }

    [HttpPost("Dishes/new")]
    public IActionResult AddDish(Dish newDish)
    {   
        if(ModelState.IsValid)
        {
            _context.Add(newDish);  
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        } 
        else {
            List<Chef> AllChefs = _context.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View("NewDish");
        }
    }

    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        List<Dish> all_dishes = _context.Dishs.ToList();
        return View(all_dishes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
