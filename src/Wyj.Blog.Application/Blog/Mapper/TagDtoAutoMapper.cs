using AutoMapper;
using Wyj.Blog.Blog.Dtos;

namespace Wyj.Blog.Blog.Mapper
{
    /// <summary>
    /// 配置Tag的AutoMapper映射
    /// 前往 <see cref="BlogApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// TagDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
    internal static class TagDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Tag, TagListDto>();
            configuration.CreateMap<TagListDto, Tag>();

            configuration.CreateMap<TagEditDto, Tag>();
            configuration.CreateMap<Tag, TagEditDto>();

            //// custom codes

            //// custom codes end
        }
    }
}