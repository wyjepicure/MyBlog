using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Wyj.Blog.Authorization;
using Wyj.Blog.Blog.Authorization;
using Wyj.Blog.Blog.Mapper;

namespace Wyj.Blog
{
    [DependsOn(
        typeof(BlogCoreModule),
        typeof(AbpAutoMapperModule))]
    public class BlogApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BlogAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CategoryAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PostAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<TagAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BlogApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg =>
                {
                    cfg.AddMaps(thisAssembly);
                    PostDtoAutoMapper.CreateMappings(cfg);
                    TagDtoAutoMapper.CreateMappings(cfg);
                    CategoryDtoAutoMapper.CreateMappings(cfg);
                });
        }
    }
}