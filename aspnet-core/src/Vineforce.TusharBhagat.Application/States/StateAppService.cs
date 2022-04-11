using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vineforce.TusharBhagat.State;
using Vineforce.TusharBhagat.State.Dto;

namespace Vineforce.TusharBhagat.States
{
    public class StateAppService : TusharBhagatAppServiceBase, IStateAppService
    {
        private readonly IRepository<State, long> _stateRepository;

        public StateAppService(IRepository<State, long> stateRepository)
        {
            _stateRepository = stateRepository;


        }
        public async Task CreateOrEdit(CreateOrEditStateDto input)
        {
            if (input.Id.HasValue)
            {
                await Update(input);
                
            }
            else
            {
                await Create(input);
            }
        }

        protected virtual async Task Create(CreateOrEditStateDto input)
        {
            var state = ObjectMapper.Map<State>(input);
            
           
            await _stateRepository.InsertAsync(state);
        }

        protected virtual async Task Update(CreateOrEditStateDto input)
        {
            var state = await _stateRepository.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input, state);
        }
        public async Task Delete(EntityDto<long> input)
        {
            await _stateRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<GetStateForViewDto>> GetAllState(GetAllStateInput input)
        {
            var filteredState = _stateRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.StateName.Contains(input.Filter))
                .WhereIf(!string.IsNullOrWhiteSpace(input.StateNameFilter), e => e.StateName == input.StateNameFilter);

            var states = from o in filteredState
                         select new GetStateForViewDto()
                          {
                              State = new StateDto
                              {
                                  StateName = o.StateName,
                                  Id = o.Id
                              }
                          };

            var totalCount = filteredState.Count();

            return new PagedResultDto<GetStateForViewDto>(
                totalCount,
                states.ToList()
            );
        }

        public async Task<GetStateForEditOutput> GetStateForEdit(EntityDto<long> input)
        {
            var state = await _stateRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetStateForEditOutput { State = ObjectMapper.Map<CreateOrEditStateDto>(state) };

            return output;
        }

        public async Task<GetStateForViewDto> GetStateForView(long id)
        {
            var state = await _stateRepository.GetAsync(id);

            var output = new GetStateForViewDto { State = ObjectMapper.Map<StateDto>(state) };

            return output;
        }
    }
}
