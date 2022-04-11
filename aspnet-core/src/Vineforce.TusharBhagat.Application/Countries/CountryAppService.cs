using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vineforce.TusharBhagat.Country;
using Vineforce.TusharBhagat.Country.Dto;

namespace Vineforce.TusharBhagat.Countries

{
    public class CountryAppService : TusharBhagatAppServiceBase, ICountryAppService
    {
        private readonly IRepository<Country, long> _countryRepository;

        public CountryAppService(IRepository<Country, long> countryRepository)
        {
            _countryRepository = countryRepository;
            

        }
        public async Task CreateOrEdit(CreateOrEditCountryDto input)
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

     
        protected virtual async Task Create(CreateOrEditCountryDto input)
        {
            var country = ObjectMapper.Map<Country>(input);

            await _countryRepository.InsertAsync(country);
        }
       
        protected virtual async Task Update(CreateOrEditCountryDto input)
        {
            var country = await _countryRepository.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input, country);
        }

     
        public async Task Delete(EntityDto<long> input)
        {
            await _countryRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<GetCountryForViewDto>> GetAllCountry(GetAllCountryInput input)
        {
            var filteredCountry = _countryRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CountryName.Contains(input.Filter))
                .WhereIf(!string.IsNullOrWhiteSpace(input.CountryNameFilter), e => e.CountryName == input.CountryNameFilter);

            var country = from o in filteredCountry
                          select new GetCountryForViewDto()
                         {
                             Country = new CountryDto
                             {
                                 CountryName = o.CountryName,
                                 Id = o.Id
                             }
                         };

            var totalCount =  filteredCountry.Count();

            return new PagedResultDto<GetCountryForViewDto>(
                totalCount,
                country.ToList()
            );
        }

        public async Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto<long> input)
        {
            var country = await _countryRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetCountryForEditOutput { Country = ObjectMapper.Map<CreateOrEditCountryDto>(country) };

            return output;
        }

        public async Task<GetCountryForViewDto> GetCountryForView(long id)
        {
            var country = await _countryRepository.GetAsync(id);

            var output = new GetCountryForViewDto { Country = ObjectMapper.Map<CountryDto>(country) };

            return output;
        }
    }
}
