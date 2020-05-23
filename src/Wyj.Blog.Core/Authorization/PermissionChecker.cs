using Abp.Authorization;
using Wyj.Blog.Authorization.Roles;
using Wyj.Blog.Authorization.Users;

namespace Wyj.Blog.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
