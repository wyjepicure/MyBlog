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
    /// See <see cref="TagPermissions" /> for all permission names. Tag
    ///</summary>
    public class TagAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public TagAuthorizationProvider()
        {
        }

        public TagAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public TagAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了Tag 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var tag = administration.CreateChildPermission(TagPermissions.Node, L("Tag"));
            tag.CreateChildPermission(TagPermissions.Query, L("QueryTag"));
            tag.CreateChildPermission(TagPermissions.Create, L("CreateTag"));
            tag.CreateChildPermission(TagPermissions.Edit, L("EditTag"));
            tag.CreateChildPermission(TagPermissions.Delete, L("DeleteTag"));
            tag.CreateChildPermission(TagPermissions.BatchDelete, L("BatchDeleteTag"));
            tag.CreateChildPermission(TagPermissions.ExportExcel, L("ExportToExcel"));

            //// custom codes

            //// custom codes end
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BlogConsts.LocalizationSourceName);
        }
    }
}