using Microsoft.AspNetCore.Mvc;

namespace lecture_3
{
    public class PriorityListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(
        int maxPriority, bool isDone)
        {
            var items = await GetItemsAsync(maxPriority, isDone);
            return View("PriorityList", items);
        }
        private async Task<List<int>> GetItemsAsync(int maxPriority, bool isDone)
        {
            return await Task.FromResult(

                 new List<int> { DateTime.Now.Minute, DateTime.Now.Millisecond }

                );

        }
    }
}
