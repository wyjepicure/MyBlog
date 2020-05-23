using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Wyj.Blog.Authorization;

namespace Wyj.Blog.Blog.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="PostPermissions" /> for all permission names. Post
    ///</summary>
    public class PostAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public PostAuthorizationProvider()
        {
        }

        public PostAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public PostAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了Post 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var post = administration.CreateChildPermission(PostPermissions.Node, L("Post"));
            post.CreateChildPermission(PostPermissions.Query, L("QueryPost"));
            post.CreateChildPermission(PostPermissions.Create, L("CreatePost"));
            post.CreateChildPermission(PostPermissions.Edit, L("EditPost"));
            post.CreateChildPermission(PostPermissions.Delete, L("DeletePost"));
            post.CreateChildPermission(PostPermissions.BatchDelete, L("BatchDeletePost"));
            post.CreateChildPermission(PostPermissions.ExportExcel, L("ExportToExcel"));

            //// custom codes

            //// custom codes end
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BlogConsts.LocalizationSourceName);
        }
    }
}