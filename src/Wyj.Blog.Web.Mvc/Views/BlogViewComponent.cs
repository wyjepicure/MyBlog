using Abp.AspNetCore.Mvc.ViewComponents;

namespace Wyj.Blog.Web.Views
{
    public abstract class BlogViewComponent : AbpViewComponent
    {
        protected BlogViewComponent()
        {
            LocalizationSourceName = BlogConsts.LocalizationSourceName;
        }
    }
}
