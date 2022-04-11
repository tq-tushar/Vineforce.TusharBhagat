using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vineforce.TusharBhagat.State.Dto
{
    public class StateDto : EntityDto<long>
    {
        public string StateName { get; set; }

        public virtual long? CountryId { get; set; }
    }
}
