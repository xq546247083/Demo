using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFDemo.DB
{
    public static class MysqlDbContentFactory
    {
        private static PooledDbContextFactory<MySQLDbContext> factory;

        static MysqlDbContentFactory()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MySQLDbContext>();
            dbContextOptionsBuilder.LogTo(msg => Console.WriteLine(msg));

            var sqlStr = "Server=127.0.0.1;Database=demo;Port=3306;charset=utf8;uid=root;pwd=123456;";
            var options = dbContextOptionsBuilder.UseMySql(sqlStr, ServerVersion.AutoDetect(sqlStr)).Options;
            factory = new PooledDbContextFactory<MySQLDbContext>(options);

            using (var dbContent = DbContent)
            {
                dbContent.Database.EnsureCreated();
            }
        }

        public static MySQLDbContext DbContent
        {
            get
            {
                return factory.CreateDbContext();
            }
        }
    }
}