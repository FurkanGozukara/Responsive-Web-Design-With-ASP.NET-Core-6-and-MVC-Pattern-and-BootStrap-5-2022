using lecture_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
 

namespace lecture_2.Controllers
{

    //https://asp.mvc-tutorial.com/views/introduction/
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

        public IActionResult index2()
        {
            return View();
        }

        [Route("/index2/customAction")]
        public IActionResult customAction()
        {
            return Content("<b>Edit</b>", "text/html");
        }

        [Route("/index2/customAction3")]
        public IActionResult customAction3()
        {
            return NotFound();
        }


        [Route("/index2/customAction2")]
        [HttpPost]
        public IActionResult customAction2()
        {
            return Content("Edit 2");
        }


        [Route("/index2/customAction4")]
        public IActionResult customAction4()
        {
            return File("~/text/a.txt", "text/plain");
        }

        [Route("/JsonResult")]
        public JsonResult JsonResult()
        {
            return Json(new { Name = "Zain Ul Hassan", ID = 1 });
        }


        [Route("/TestAjax")]
        public ActionResult TestAjax( )
        {
            return Content("<script language='javascript' type='text/javascript'>alert('Hello world!');</script>", "text/html");
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

        [Route("/Indexgg")]
        public IActionResult Indexgg()
        {
            return Unauthorized("you can not access");
        }
    }
}