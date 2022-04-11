using Abp.Authorization;
using Vineforce.TusharBhagat.Authorization.Roles;
using Vineforce.TusharBhagat.Authorization.Users;

namespace Vineforce.TusharBhagat.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
