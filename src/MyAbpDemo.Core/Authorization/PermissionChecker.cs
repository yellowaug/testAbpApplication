using Abp.Authorization;
using MyAbpDemo.Authorization.Roles;
using MyAbpDemo.Authorization.Users;

namespace MyAbpDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
