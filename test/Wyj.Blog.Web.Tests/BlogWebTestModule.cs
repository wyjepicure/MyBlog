using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Wyj.Blog.EntityFrameworkCore;
using Wyj.Blog.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Wyj.Blog.Web.Tests
{
    [DependsOn(
        typeof(BlogWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BlogWebTestModule : AbpModule
    {
        public BlogWebTestModule(BlogEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BlogWebMvcModule).Assembly);
        }
    }
}