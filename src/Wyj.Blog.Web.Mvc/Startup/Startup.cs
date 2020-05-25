using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.Castle.Logging.Log4Net;
using Wyj.Blog.Authentication.JwtBearer;
using Wyj.Blog.Configuration;
using Wyj.Blog.Identity;
using Wyj.Blog.Web.Resources;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Dependency;
using Abp.Json;
using LogDashboard;
using LogDashboard.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Filters;

namespace Wyj.Blog.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
            _env = env;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddControllersWithViews(
                    options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                        options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
                    }
                )
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new AbpMvcContractResolver(IocManager.Instance)
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                });

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddSignalR();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "MyBlog API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);

                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                // Assign scope requirements to operations based on AuthorizeAttribute
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddLogDashboard(opt =>
            {
                opt.SetRootPath(_env.ContentRootPath);

                //        opt.AddAuthorizeAttribute(new AbpMvcAuthorizeAttribute(PermissionNames.Pages_Users));
            });
            // Configure Abp and Dependency Injection
            return services.AddAbp<BlogWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseLogDashboard();
            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AbpCommonHub>("/signalr");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CourierStation API V1");
                //options.IndexStream = () => Assembly.GetAssembly(typeof(Startup))
                //    .GetManifestResourceStream("Wyj.Blog.Web.wwwroot.swagger.ui.index.html");
            }); // URL: /swagger
        }
    }
}