using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Wyj.Blog.Authorization.Roles;
using Wyj.Blog.Authorization.Users;
using Wyj.Blog.MultiTenancy;

namespace Wyj.Blog.EntityFrameworkCore
{
    public class BlogDbContext : AbpZeroDbContext<Tenant, Role, User, BlogDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
    }
}
