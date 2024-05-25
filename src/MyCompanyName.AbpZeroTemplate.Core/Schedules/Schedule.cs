using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Schedules
{
    [Table("PbMeal")]
    public class Schedule : FullAuditedEntity
    {
        public virtual uint Week { get; set; }
        public virtual string Weekday { get; set; }
        public virtual string FirstMeal { get; set; }
        public virtual string Lunch { get; set;}
        public virtual string LastMeal { get; set;}

    }
}
