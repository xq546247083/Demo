using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RazorDemo.Authorization;
using RazorDemo.Data.Context;
using RazorDemo.Data.Enum;
using RazorDemo.Data.Model;

namespace RazorDemo.Pages.Movies
{
    [Authorize]
    public class CreateModel : RazorDemoPageModel
    {
        public CreateModel(RazorDemoContext context,
            IAuthorizationService authorizationService,
            UserManager<User> userManager):base(context, authorizationService,userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        [TempData]
        public string Message
        {
            get; set;
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, Movie, Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Movie.Status = MovieStatus.Submitted;
            Movie.OwnerID = CurrentUser?.Id;
            DBContext.Movie.Add(Movie);
            await DBContext.SaveChangesAsync();

            Message = $"Movie {Movie.Title} added";
            return RedirectToPage("./Index");
        }
    }
}
