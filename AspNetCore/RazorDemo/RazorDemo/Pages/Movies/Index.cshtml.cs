using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorDemo.Authorization;
using RazorDemo.Data.Context;
using RazorDemo.Data.Enum;
using RazorDemo.Data.Model;

namespace RazorDemo.Pages.Movies
{
    [Authorize]
    public class IndexModel : RazorDemoPageModel
    {
        public IndexModel(RazorDemoContext context,
           IAuthorizationService authorizationService,
           UserManager<User> userManager) : base(context, authorizationService, userManager)
        {
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
            var genreQuery = from m in DBContext.Movie
                                            orderby m.Genre
                                            select m.Genre;
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            var movies = from m in DBContext.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title != null && s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            var isAuthorized = User.IsInRole(Constants.ManagersRole) || User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                var currentUserId = CurrentUser?.Id;
                movies = movies.Where(c => c.Status == MovieStatus.Approved || c.OwnerID == currentUserId);
            }

            Movie = await movies.ToListAsync();
        }
    }
}
