using lecture___4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using lecture___4.DbModels;

namespace lecture___4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()//signature empty
        {
            ViewData["Title"] = "my awesome page";

            //WebUser gg = TempData.Get<WebUser>("savedUser");
           
            //if (gg != null)
            //{
            //    this.ModelState.Merge(JsonConvert.SerializeObject(serializableModelState););
            //    return View(gg);
            //}
            return View();
        }

        [ActionName("IndexWithModel")]
        public IActionResult Index(WebUser ggUser)//signature webuser
        {
            return View("Index", ggUser);
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

        [Route("Test")]
        public IActionResult Test()
        {
            ViewData["Title"] = "this is test";
            return View("Index");
        }


    }
}