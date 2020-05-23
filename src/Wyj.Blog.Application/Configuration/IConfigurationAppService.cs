using System.Threading.Tasks;
using Wyj.Blog.Configuration.Dto;

namespace Wyj.Blog.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
