using Abp.Application.Services.Dto;


namespace Vineforce.TusharBhagat.Country.Dto
{
   public class CountryDto : EntityDto<long>
    {
        public string CountryName { get; set; }
    }
}
