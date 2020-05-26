using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Caching.Redis;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Wyj.Blog.Authorization.Roles;
using Wyj.Blog.Authorization.Users;
using Wyj.Blog.Configuration;
using Wyj.Blog.Localization;
using Wyj.Blog.MultiTenancy;
using Wyj.Blog.Timing;

namespace Wyj.Blog
{
    [DependsOn(typeof(AbpZeroCoreModule),
        typeof(AbpRedisCacheModule))]
    public class BlogCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Caching.UseRedis(op => op.ConnectionString = "127.0.0.1:6379");
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            BlogLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = BlogConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}