using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vineforce.TusharBhagat.Countries
{
    [Table("Country")]
    public class Country : FullAuditedEntity<long>
    {
        public virtual string CountryName { get; set; }

        public static implicit operator Country(long? v)
        {
            throw new NotImplementedException();
        }
    }
}
