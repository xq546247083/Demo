using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RazorDemo.Data.Context
{
    public class RazorDemoContext : IdentityDbContext
    {
        public RazorDemoContext (DbContextOptions<RazorDemoContext> options)
            : base(options)
        {
        }

        public DbSet<RazorDemo.Data.Model.Movie> Movie { get; set; } = default!;
    }
}
