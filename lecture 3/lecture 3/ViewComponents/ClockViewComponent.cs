using Microsoft.AspNetCore.Mvc;

namespace lecture_3.ViewComponents
{
    public class ClockViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Clock");
        }
    }
}
