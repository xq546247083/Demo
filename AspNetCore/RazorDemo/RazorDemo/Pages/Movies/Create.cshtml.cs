using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RazorDemo.Data.Context;
using RazorDemo.Data.Enum;
using RazorDemo.Data.Model;

namespace RazorDemo.Pages.Movies
{
    [Authorize]
    public class CreateModel : RazorDemoPageModel
    {
        private readonly RazorDemoContext _context;

        public CreateModel(RazorDemoContext context)
        {
            _context = context;
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

            Movie.Status = ContactStatus.Approved;
            Movie.OwnerID = CurrentUser?.Id;
            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            Message = $"Movie {Movie.Title} added";
            return RedirectToPage("./Index");
        }
    }
}
