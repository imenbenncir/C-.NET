using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

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
        List<Dish> all_dishs = _context.Dishs.ToList();
        return View(all_dishs);
    }
    

    [HttpGet("Dishs/new")]
    public IActionResult NewDish ()
    {
        return View();
    }

    [HttpPost("Dishs/create")]
    public IActionResult NewDish(Dish newDish)
    {    
        if(ModelState.IsValid)
        {
            _context.Add(newDish);  
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
        else {
            return View("NewDish");
        }
    }
    [HttpGet("dishs/{dishId}")]
    public IActionResult DishById(int dishId)
    {
        Dish dish = _context.Dishs.FirstOrDefault(d => d.Id == dishId);
        return View(dish);
    }
    
    [HttpGet("dishs/edit/{dishsID}")]
    public IActionResult EditDish(int dishID)
    {
        Dish dishToUpdate = _context.Dishs.SingleOrDefault(d => d.Id == dishID);
        return View(dishToUpdate);
    }
    public IActionResult UpdateDish(int dishId, Dish editDish)
    {
        Dish CRUDeliciousDB = _context.Dishs.FirstOrDefault(d => d.Id == dishId);

        if (ModelState.IsValid)
        {

            CRUDeliciousDB.ChefName = editDish.ChefName;
            CRUDeliciousDB.NameofDish= editDish.NameofDish;
            CRUDeliciousDB.Tastiness = editDish.Tastiness;
            CRUDeliciousDB.Description = editDish.Description;
            CRUDeliciousDB.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("DishById", new { dishId });
        }

        return View("EditDish", CRUDeliciousDB);
    }
    public IActionResult DeleteDish(int dishId)
    {
        Dish dishToDelete = _context.Dishs.FirstOrDefault(d => d.Id == dishId);
        _context.Dishs.Remove(dishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
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
