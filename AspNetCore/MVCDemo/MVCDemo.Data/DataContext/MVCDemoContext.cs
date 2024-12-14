using Microsoft.EntityFrameworkCore;

namespace MVCDemo.Data.DataContext
{
    public class MVCDemoContext : DbContext
    {
        public MVCDemoContext (DbContextOptions<MVCDemoContext> options)
            : base(options)
        {
        }

        public DbSet<MVCDemo.Data.Model.Movie> Movie { get; set; } = default!;
    }
}