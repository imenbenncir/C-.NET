using Microsoft.AspNetCore.Mvc;
namespace RazorFun.Controllers;   
public class RazorFunController : Controller 
{      
    [HttpGet("")]  
    public ViewResult Index()        
    {            
        return View ();        
    }
}