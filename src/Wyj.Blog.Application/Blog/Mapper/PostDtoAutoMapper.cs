using AutoMapper;
using Wyj.Blog.Blog.Dtos;

namespace Wyj.Blog.Blog.Mapper
{
    /// <summary>
    /// 配置Post的AutoMapper映射
    /// 前往 <see cref="BlogApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// PostDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
    internal static class PostDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostDto>();
            configuration.CreateMap<PostDto, Post>();

            configuration.CreateMap<PostEditDto, Post>();
            configuration.CreateMap<Post, PostEditDto>();

            //// custom codes

            //// custom codes end
        }
    }
}