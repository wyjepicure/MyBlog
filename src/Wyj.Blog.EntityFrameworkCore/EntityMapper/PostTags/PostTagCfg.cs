

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wyj.Blog.Blog;

namespace Wyj.Blog.EntityMapper.PostTags
{
    public class PostTagCfg : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {

			 
      //   builder.ToTable("PostTags", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("PostTags");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


