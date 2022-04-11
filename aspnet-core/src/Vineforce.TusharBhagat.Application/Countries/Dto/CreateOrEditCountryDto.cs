using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vineforce.TusharBhagat.Country.Dto
{
   public class CreateOrEditCountryDto : EntityDto<long?>
    {
        public string CountryName { get; set; }
    }
}
