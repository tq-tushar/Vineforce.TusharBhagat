using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vineforce.TusharBhagat.Countries;

namespace Vineforce.TusharBhagat.States
{
   public class State : FullAuditedEntity<long>
    {
        public virtual string  StateName { get; set; }

        public virtual long? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country ContryFk { get; set; }
    }
}
