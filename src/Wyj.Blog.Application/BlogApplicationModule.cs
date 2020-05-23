using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Wyj.Blog.Authorization;

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
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BlogApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
