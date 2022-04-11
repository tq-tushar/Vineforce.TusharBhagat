using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vineforce.TusharBhagat.State.Dto;

namespace Vineforce.TusharBhagat.State
{
   public interface IStateAppService: IApplicationService
    {
        Task<PagedResultDto<GetStateForViewDto>> GetAllState(GetAllStateInput input);

        Task<GetStateForViewDto> GetStateForView(long id);

        Task<GetStateForEditOutput> GetStateForEdit(EntityDto<long> input);

        Task CreateOrEdit(CreateOrEditStateDto input);

        Task Delete(EntityDto<long> input);
    }
}
