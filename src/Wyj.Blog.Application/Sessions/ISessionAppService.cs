using System.Threading.Tasks;
using Abp.Application.Services;
using Wyj.Blog.Sessions.Dto;

namespace Wyj.Blog.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
