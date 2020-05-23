using System.Collections.Generic;
using Wyj.Blog.Roles.Dto;

namespace Wyj.Blog.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
