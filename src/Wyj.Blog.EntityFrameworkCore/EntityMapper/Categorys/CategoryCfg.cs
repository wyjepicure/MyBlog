

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wyj.Blog.Blog;

namespace Wyj.Blog.EntityMapper.Categorys
{
    public class CategoryCfg : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

			 
      //   builder.ToTable("Categorys", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("Categorys");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


