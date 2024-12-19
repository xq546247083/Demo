using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Data.DataContext;
using MVCDemo.Data.Model;

namespace MVCDemo.ViewComponents
{
    public class MovieList : ViewComponent
    {
        private readonly MVCDemoContext _context;

        public MovieList(MVCDemoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string componentName, int maxCount)
        {
            var items = await GetItemsAsync(maxCount);
            return View(componentName, items);
        }

        private Task<List<Movie>> GetItemsAsync(int maxCount)
        {
            return _context!.Movie!.Take(maxCount).ToListAsync();
        }
    }
}