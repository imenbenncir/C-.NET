using Microsoft.AspNetCore.Mvc;

namespace DojoSurveyModel.Controllers
{
public class DojoSurveyController : Controller
    {
        private static string Name = string.Empty;
        private static string Location = string.Empty;
        private static string FavLang = string.Empty;
        private static string Comment = string.Empty;


        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult Process(string name, string location, string favLang, string comment)
        {
            Name = name;
            Location = location;
            FavLang = favLang;
            Comment = comment;
            return RedirectToAction("Results");
        }

        [HttpGet("results")]
        public IActionResult Results()
        {
            string commentToShow = string.IsNullOrEmpty(Comment) ? "No comment" : Comment;

            ViewData["Name"] = Name;
            ViewData["Location"] = Location;
            ViewData["FavLang"] = FavLang;
            ViewData["Comment"] = commentToShow;

            return View();
        }

        public IActionResult GoBack()
        {
            return RedirectToAction("Index");
        }
    }
}
