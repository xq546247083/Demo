using Microsoft.EntityFrameworkCore;

namespace RazorDemo.Data.Context
{
    public class RazorDemoContext : DbContext
    {
        public RazorDemoContext (DbContextOptions<RazorDemoContext> options)
            : base(options)
        {
        }

        public DbSet<RazorDemo.Data.Model.Movie> Movie { get; set; } = default!;
    }
}
