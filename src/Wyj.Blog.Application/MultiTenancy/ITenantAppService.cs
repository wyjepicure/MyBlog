using Abp.Application.Services;
using Wyj.Blog.MultiTenancy.Dto;

namespace Wyj.Blog.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

