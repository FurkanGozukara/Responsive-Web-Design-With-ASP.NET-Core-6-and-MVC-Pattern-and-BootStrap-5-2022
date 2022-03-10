using lecture_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lecture_1.Controllers
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
            return View("Views/CustomViews/Test2.cshtml");
        }

        [Route("benimdenemesayfam")]
        [Route("home/test3")]
        public IActionResult Test3()
        {
            return View();
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
}