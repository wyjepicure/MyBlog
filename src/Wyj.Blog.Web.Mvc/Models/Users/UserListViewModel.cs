using System.Collections.Generic;
using Wyj.Blog.Roles.Dto;

namespace Wyj.Blog.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
