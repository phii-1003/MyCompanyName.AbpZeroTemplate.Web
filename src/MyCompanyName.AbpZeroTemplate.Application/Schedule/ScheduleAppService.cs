using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Schedule.Dto;
using MyCompanyName.AbpZeroTemplate.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Schedule
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_Schedule)]
    public class ScheduleAppService: AbpZeroTemplateAppServiceBase, IScheduleAppService
    {
        private readonly IRepository<MyCompanyName.AbpZeroTemplate.Schedules.Schedule> _scheduleRepository;
        public ScheduleAppService(IRepository<MyCompanyName.AbpZeroTemplate.Schedules.Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<PagedResultDto<ScheduleListDto>> GetSchedule(GetScheduleInput input)
        {
            var query = CreateScheduleQuery(input);

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(p => p.Week)
                .PageBy(input)
                .ToListAsync();

            var scheduleListDtos = ConvertToScheduleListDtos(results);

            return new PagedResultDto<ScheduleListDto>(resultCount, scheduleListDtos);
        }
        public async Task CreateSchedule(ScheduleCreateDto input)
        {
            var schedule = ObjectMapper.Map<MyCompanyName.AbpZeroTemplate.Schedules.Schedule>(input);
            await _scheduleRepository.InsertAsync(schedule);
        }

        public async Task DeleteSchedule(EntityDto input)
        {
            await _scheduleRepository.DeleteAsync(input.Id);
        }

        public async Task EditSchedule(EntityDto input)
        {
            var result = await _scheduleRepository.FirstOrDefaultAsync(input.Id);
            if (result == null)
            {
                return;
            }
        }

        private List<ScheduleListDto> ConvertToScheduleListDtos(List<MyCompanyName.AbpZeroTemplate.Schedules.Schedule> results)
        {
            return results.Select(
                result =>
                {
                    var scheduleListDto = ObjectMapper.Map<ScheduleListDto>(result);
                    return scheduleListDto;
                }).ToList();
        }

        private IQueryable<MyCompanyName.AbpZeroTemplate.Schedules.Schedule> CreateScheduleQuery(GetScheduleInput input)
        {
            var query = from e in _scheduleRepository.GetAll()
                        select new MyCompanyName.AbpZeroTemplate.Schedules.Schedule
                        {
                            Week = e.Week
                        };

            query = query
                .WhereIf(input.Week > 0, p => p.Week == input.Week);
            return query;
        }
    }
}
