using Abp.AutoMapper;
using Wyj.Blog.Roles.Dto;
using Wyj.Blog.Web.Models.Common;

namespace Wyj.Blog.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
