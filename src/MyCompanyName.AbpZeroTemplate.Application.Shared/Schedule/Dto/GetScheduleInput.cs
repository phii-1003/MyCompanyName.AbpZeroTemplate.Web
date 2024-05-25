using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Schedule.Dto
{
    public class GetScheduleInput : PagedAndSortedInputDto
    {
        public uint Week { get; set; }
    }
    public class ScheduleListDto : FullAuditedEntityDto
    {
        public uint Week { get; set; }
        public string Weekday { get; set; }

        public string FirstMeal { get; set; }
        public string Lunch { get; set; }
        public string LastMeal { get; set;}
    }
}
