using lecture_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lecture_3.Controllers
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
            ViewBag.MovieName = "Titanic";
            ViewBag.Year = 1997;

            ViewData["ProductTitle"] = "Toilet Paper";
            ViewData["myList"] = new List<int> { 32, 111, 222, 3330000 };

            HttpContext.Session.SetString("a", "The Doctor");

            HelperClasses.SessionHelper.SetObjectAsJson(HttpContext.Session, "a", "The Doctor");

            return View("/Views/CustomViews/myView.cshtml");
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

        public ActionResult Foo()
        {
            TempData["foo"] = "bar";
            return RedirectToAction("bar");
        }

        public ActionResult Bar()
        {
            var value = TempData["foo"] as string;
            // use the value here. If you need to pass it to the view you could
            // use ViewData/ViewBag (I can't believe I said that but I will leave it for the moment)
            return View("/Views/CustomViews/myView.cshtml");
        }

        public IActionResult PriorityList()
        {
            return ViewComponent("PriorityList");
        }

        public IActionResult Clock()
        {
            return ViewComponent("Clock");
        }
    }
}