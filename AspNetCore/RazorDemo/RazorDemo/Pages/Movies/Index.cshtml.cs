using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorDemo.Data.Context;
using RazorDemo.Data.Model;

namespace RazorDemo.Pages.Movies
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly RazorDemoContext _context;

        public IndexModel(RazorDemoContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString
        {
            get; set;
        }

        public SelectList? Genres
        {
            get; set;
        }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre
        {
            get; set;
        }

        public async Task OnGetAsync()
        {
            var genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title != null && s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Movie = await movies.ToListAsync();
        }
    }
}
