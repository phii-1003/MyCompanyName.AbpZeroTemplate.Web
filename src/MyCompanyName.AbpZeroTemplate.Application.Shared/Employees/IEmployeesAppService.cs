using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Auditing.Dto;
using MyCompanyName.AbpZeroTemplate.Employees.Dto;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Employees
{
    public interface IEmployeesAppService : IApplicationService
    {
        //ListResultDto<Dto.EmployeeListDto> GetEmployees(Dto.GetEmployeesInput input);
        Task<PagedResultDto<Dto.EmployeeListDto>> GetEmployees(GetEmployeesInput input);
    }
}