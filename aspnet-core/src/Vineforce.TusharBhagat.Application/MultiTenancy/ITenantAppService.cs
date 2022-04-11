using Abp.Application.Services;
using Vineforce.TusharBhagat.MultiTenancy.Dto;

namespace Vineforce.TusharBhagat.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

