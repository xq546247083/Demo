using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDemo.Pages
{
    [Authorize(Policy = "AtLeast21")]
    public class MinAgeDemoModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public MinAgeDemoModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}