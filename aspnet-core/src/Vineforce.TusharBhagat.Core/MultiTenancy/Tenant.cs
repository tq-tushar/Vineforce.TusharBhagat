using Abp.MultiTenancy;
using Vineforce.TusharBhagat.Authorization.Users;

namespace Vineforce.TusharBhagat.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
