using Microsoft.AspNetCore.Mvc;

namespace lecture___4.Controllers
{
    [Route("/products")]
    public class Page2Controller : Controller
    {
        [Route("",Order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/products/details/{id2}")]
        [Route("{id}")]
        public IActionResult Details(int id2)
        {
            return Content("Product #" + id2);
        }

        [Route("{id?}", Order = 0)]
        public IActionResult Details2(int id)
        {
            return Content("Product #" + id);
        }

        [Route("/blog/{entryId}/{slug}")]
        public IActionResult Blog(int entryId, string slug)
        {
            return Content($"Blog entry with ID #{entryId} requested (URL Slug: {slug})");
        }

        [Route("/blog2/{entryId}/{*slug}")]
        public IActionResult Blog2(int entryId, string slug)
        {
            return Content($"Blog2 entry with ID #{entryId} requested (URL Slug: {slug})");
        }


        [Route("/blog3/{entryId}/{slug?}")]
        public IActionResult Blog3(int entryId, string slug)
        {
            return Content($"Blog3 entry with ID #{entryId} requested (URL Slug: {slug})");
        }

        [Route("/action/{entryId}/{slug?}")]
        public IActionResult Blog4(int entryId, string slug)
        {
            return Content($"Blog4 entry with ID #{entryId} requested (URL Slug: {slug})");
        }

        //[Route(@"blog/{slug:regex(^[[0-9]]{{1,7}}\-[[a-z0-9\-]]{{3,50}}$)}")]   
        //[Route("blog/{entryId:int:range(1, 999999)}/{slug:minlength(3):maxlength(50)}")]
        //[Route("blog/{entryId:range(1, 999999)}/{slug:minlength(3)}")]
        // [Route("blog/{entryId:range(1, 999999)}/{slug}")]
        // [Route("blog/{entryId:min(1)}/{slug}")]
        [Route("/blog5/{entryId:int}/{slug:minlength(3)}")]
        public IActionResult Blog5(int entryId, string slug)
        {
            return Content($"Blog5 entry with ID #{entryId} requested (URL Slug: {slug})");
        }
    }
}
