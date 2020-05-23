using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Wyj.Blog.Authorization.Roles;
using Wyj.Blog.Authorization.Users;
using Wyj.Blog.Blog;
using Wyj.Blog.MultiTenancy;

namespace Wyj.Blog.EntityFrameworkCore
{
    public class BlogDbContext : AbpZeroDbContext<Tenant, Role, User, BlogDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Category> Categories { get; set; }
        public DbSet<FriendLink> FriendLinks { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
    }
}