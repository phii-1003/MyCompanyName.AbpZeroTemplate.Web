using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Schedule.Dto
{
    public class ScheduleCreateDto
    {
        public uint Week { get; set; }
        public string Weekday { get; set; }
        public string FirstMeal { get; set; }
        public string Lunch { get; set; }
        public string LastMeal { get; set; }
    }
}
