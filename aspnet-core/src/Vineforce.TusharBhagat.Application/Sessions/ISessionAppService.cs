using System.Threading.Tasks;
using Abp.Application.Services;
using Vineforce.TusharBhagat.Sessions.Dto;

namespace Vineforce.TusharBhagat.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
