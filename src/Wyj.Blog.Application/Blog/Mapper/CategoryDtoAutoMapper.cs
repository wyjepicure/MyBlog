using AutoMapper;
using Wyj.Blog.Blog.Dtos;

namespace Wyj.Blog.Blog.Mapper
{
    /// <summary>
    /// 配置Category的AutoMapper映射
    /// 前往 <see cref="BlogApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// CategoryDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
    internal static class CategoryDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, CategoryListDto>();
            configuration.CreateMap<CategoryListDto, Category>();

            configuration.CreateMap<CategoryEditDto, Category>();
            configuration.CreateMap<Category, CategoryEditDto>();

            //// custom codes

            //// custom codes end
        }
    }
}