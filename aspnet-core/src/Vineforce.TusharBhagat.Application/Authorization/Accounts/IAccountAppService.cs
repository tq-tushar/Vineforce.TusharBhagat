using System.Threading.Tasks;
using Abp.Application.Services;
using Vineforce.TusharBhagat.Authorization.Accounts.Dto;

namespace Vineforce.TusharBhagat.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
