using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorDemo.Data.Model;

namespace RazorDemo.Data.Context
{
    public class RazorDemoContext : IdentityDbContext<User>
    {
        public RazorDemoContext (DbContextOptions<RazorDemoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<RazorDemo.Data.Model.Movie> Movie { get; set; } = default!;
    }
}
