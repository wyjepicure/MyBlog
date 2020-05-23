using System.Threading.Tasks;
using Abp.Application.Services;
using Wyj.Blog.Authorization.Accounts.Dto;

namespace Wyj.Blog.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
