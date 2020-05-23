using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Wyj.Blog.EntityFrameworkCore
{
    public static class BlogDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BlogDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BlogDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
