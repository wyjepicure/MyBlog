using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wyj.Blog.Blog;

namespace Wyj.Blog.EntityMapper.Posts
{
    public class PostCfg : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //   builder.ToTable("Posts", YoYoAbpefCoreConsts.SchemaNames.CMS);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(10);
            builder.Property(x => x.Url).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Html).HasColumnType("longtext").IsRequired();
            builder.Property(x => x.Markdown).HasColumnType("longtext").IsRequired();
            builder.Property(x => x.CategoryId).HasColumnType("int");
            builder.Property(x => x.CreationTime).HasColumnType("datetime");
            //可以自定义配置参数内容

            //// custom codes

            //// custom codes end
        }
    }
}