using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Data.DataContext
{
    public class BlazorDemoContext : DbContext
    {
        public BlazorDemoContext (DbContextOptions<BlazorDemoContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorDemo.Data.Model.Movie> Movie { get; set; } = default!;
    }
}
