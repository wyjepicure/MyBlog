using Abp.Application.Services.Dto;

namespace Wyj.Blog.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

