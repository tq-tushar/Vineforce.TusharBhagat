using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vineforce.TusharBhagat.Country.Dto;

namespace Vineforce.TusharBhagat.Country
{
   public interface ICountryAppService : IApplicationService
    {

        Task<PagedResultDto<GetCountryForViewDto>> GetAllCountry(GetAllCountryInput input);

        Task<GetCountryForViewDto> GetCountryForView(long id);

        Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto<long> input);

        Task CreateOrEdit(CreateOrEditCountryDto input);

        Task Delete(EntityDto<long> input);
        

        
    }
}
