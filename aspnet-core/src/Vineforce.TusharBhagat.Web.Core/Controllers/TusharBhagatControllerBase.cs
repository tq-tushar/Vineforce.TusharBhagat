using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Vineforce.TusharBhagat.Controllers
{
    public abstract class TusharBhagatControllerBase: AbpController
    {
        protected TusharBhagatControllerBase()
        {
            LocalizationSourceName = TusharBhagatConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
