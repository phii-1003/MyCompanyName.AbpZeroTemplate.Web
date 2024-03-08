using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.Employees
{
    public interface IEmployeesAppService : IApplicationService
    {
        ListResultDto<Dto.EmployeeListDto> GetEmployees(Dto.GetEmployeesInput input);
    }
}