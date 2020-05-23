

using Abp.Domain.Services;

namespace Wyj.Blog
{
	public abstract class BlogDomainServiceBase : DomainService
	{
		/* Add your common members for all your domain services. */
		/*在领域服务中添加你的自定义公共方法*/





		protected BlogDomainServiceBase()
		{
			LocalizationSourceName = BlogConsts.LocalizationSourceName;
		}
	}
}
