using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Employees.Dto;
using MyCompanyName.AbpZeroTemplate.Schedule.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Schedule
{
    public interface IScheduleAppService : IApplicationService
    {
        Task<PagedResultDto<Dto.ScheduleListDto>> GetSchedule(GetScheduleInput input);

        Task CreateSchedule(ScheduleCreateDto input);

        Task EditSchedule(EntityDto input);

        Task DeleteSchedule(EntityDto input);
    }
}
