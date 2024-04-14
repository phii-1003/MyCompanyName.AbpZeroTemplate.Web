using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Auditing;
using MyCompanyName.AbpZeroTemplate.Auditing.Dto;
using MyCompanyName.AbpZeroTemplate.Employees.Dto;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Employees
{
    public class EmployeesAppService: AbpZeroTemplateAppServiceBase, IEmployeesAppService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesAppService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /*public ListResultDto<EmployeeListDto> GetEmployees(GetEmployeesInput input)
        {
            var employees = _employeeRepository
            .GetAll()
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) ||
                     p.EmployeeID.Contains(input.Filter)
            )
            .OrderBy(p => p.Name)
            .ThenBy(p => p.EmployeeID)
            .ToList();

            return new ListResultDto<EmployeeListDto>(ObjectMapper.Map<List<EmployeeListDto>>(employees));
        }*/

        public async Task<PagedResultDto<EmployeeListDto>> GetEmployees(GetEmployeesInput input)
        {
            var query = CreateEmployeesQuery(input);

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(p => p.Name)
                .ThenBy(p => p.EmployeeID)
                .PageBy(input)
                .ToListAsync();

            var employeeListDtos = ConvertToEmployeeListDtos(results);

            return new PagedResultDto<EmployeeListDto>(resultCount, employeeListDtos);
        }

        private List<EmployeeListDto> ConvertToEmployeeListDtos(List<Employee> results)
        {
            return results.Select(
                result =>
                {
                    var employeeListDto = ObjectMapper.Map<EmployeeListDto>(result);
                    return employeeListDto;
                }).ToList();
        }

        private IQueryable<Employee> CreateEmployeesQuery(GetEmployeesInput input)
        {
            var query = from e in _employeeRepository.GetAll()
                        select new Employee { 
                            EmployeeID = e.EmployeeID, 
                            Name = e.Name 
                        };

            query = query
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), p => p.Name.Contains(input.Filter) || p.EmployeeID.Contains(input.Filter));
            return query;
        }
    }
}
