using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using MyCompanyName.AbpZeroTemplate.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Employees
{
    public class EmployeesAppService: AbpZeroTemplateAppServiceBase, IEmployeesAppService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesAppService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ListResultDto<EmployeeListDto> GetEmployees(GetEmployeesInput input)
        {
            var employees = _employeeRepository
            .GetAll()
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) ||
                     p.SSN.Contains(input.Filter) ||
                     p.EmployeeID.Contains(input.Filter)
            )
            .OrderBy(p => p.Name)
            .ToList();

            return new ListResultDto<EmployeeListDto>(ObjectMapper.Map<List<EmployeeListDto>>(employees));
        }
    }
}
