

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
        builder.ToTable("Posts");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


