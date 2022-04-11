using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vineforce.TusharBhagat.Country.Dto;

namespace Vineforce.TusharBhagat.Countries.Dto
{
    public class CountryMapProfile : Profile
    {
        public CountryMapProfile()
        {
            CreateMap<CreateOrEditCountryDto, Country>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
        }
    }
}
