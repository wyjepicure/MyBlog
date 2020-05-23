

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wyj.Blog.Blog;

namespace Wyj.Blog.EntityMapper.Tags
{
    public class TagCfg : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {

			 
      //   builder.ToTable("Tags", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("Tags");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


