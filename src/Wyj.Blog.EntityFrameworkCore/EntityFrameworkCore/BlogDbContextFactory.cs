using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Wyj.Blog.Configuration;
using Wyj.Blog.Web;

namespace Wyj.Blog.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BlogDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BlogDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BlogConsts.ConnectionStringName));

            return new BlogDbContext(builder.Options);
        }
    }
}
