using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginandRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoginandRegistration.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger ,MyContext context )
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("User/create")]
    public IActionResult Create(User newUser)
    {    
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password); 
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Index");
        } 
        else {
            return View("Index");
            }
    }
    [SessionCheck] 
    [HttpGet("Success")]
    public IActionResult Success()
    {
        return View(); 
    }
    [HttpPost("User/login")]
    public IActionResult Login(Login loginUser)
    {
        if(ModelState.IsValid)
        {
            User UserInDB = _context.Users.FirstOrDefault(a => a.Email == loginUser.LoginEmail);
            if (UserInDB == null)
            {
                ModelState.AddModelError("LogEmail","Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<User> hashehr = new PasswordHasher<User>();
            var result = hashehr.VerifyHashedPassword(UserInDB, UserInDB.Password , loginUser.Password);
            if (result == 0)
            {
                ModelState.AddModelError("LogEmail","Invalid Email/Password");
                return View("Index");
            }
            else{
                HttpContext.Session.SetInt32("UserId", UserInDB.UserId);
                return RedirectToAction ("Success");
            }
            return RedirectToAction("Success");
        } 
        else 
        {
            return View("Index");
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout ()
    {
        HttpContext.Session.Clear();
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

    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Find the session, but remember it may be null so we need int?
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            // Check to see if we got back null
            if(userId == null)
            {
                // Redirect to the Index page if there was nothing in session
                // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
