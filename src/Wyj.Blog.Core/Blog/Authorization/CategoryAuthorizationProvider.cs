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
    /// See <see cref="CategoryPermissions" /> for all permission names. Category
    ///</summary>
    public class CategoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public CategoryAuthorizationProvider()
        {
        }

        public CategoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CategoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了Category 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var category = administration.CreateChildPermission(CategoryPermissions.Node, L("Category"));
            category.CreateChildPermission(CategoryPermissions.Query, L("QueryCategory"));
            category.CreateChildPermission(CategoryPermissions.Create, L("CreateCategory"));
            category.CreateChildPermission(CategoryPermissions.Edit, L("EditCategory"));
            category.CreateChildPermission(CategoryPermissions.Delete, L("DeleteCategory"));
            category.CreateChildPermission(CategoryPermissions.BatchDelete, L("BatchDeleteCategory"));
            category.CreateChildPermission(CategoryPermissions.ExportExcel, L("ExportToExcel"));

            //// custom codes

            //// custom codes end
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BlogConsts.LocalizationSourceName);
        }
    }
}