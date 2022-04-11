using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vineforce.TusharBhagat.State.Dto
{
   public class GetAllStateInput: PagedAndSortedResultRequestDto
    {

        public string Filter { get; set; }

        public string StateNameFilter { get; set; }

        public long? CountryId { get; set; }
    }
}
