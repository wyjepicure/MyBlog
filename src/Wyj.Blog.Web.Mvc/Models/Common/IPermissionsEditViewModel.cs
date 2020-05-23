using System.Collections.Generic;
using Wyj.Blog.Roles.Dto;

namespace Wyj.Blog.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}