using EFDemo.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFDemo.DB
{
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Book> Books
        {
            get; set;
        }

        public DbSet<Label> Labels
        {
            get; set;
        }
    }
}