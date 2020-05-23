using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Wyj.Blog.Configuration;

namespace Wyj.Blog.Web.Host.Startup
{
    [DependsOn(
       typeof(BlogWebCoreModule))]
    public class BlogWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BlogWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogWebHostModule).GetAssembly());
        }
    }
}
