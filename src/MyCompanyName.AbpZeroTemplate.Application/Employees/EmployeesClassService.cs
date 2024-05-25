using Abp.Application.Features;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Auditing;
using MyCompanyName.AbpZeroTemplate.Auditing.Dto;
using MyCompanyName.AbpZeroTemplate.Editions.Dto;
using MyCompanyName.AbpZeroTemplate.Editions;
using MyCompanyName.AbpZeroTemplate.Employees.Dto;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using MyCompanyName.AbpZeroTemplate.Authorization;

namespace MyCompanyName.AbpZeroTemplate.Employees
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_Employees)]
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
        public async Task CreateEmployee(EmployeeCreateDto input)
        {
            var employee = ObjectMapper.Map<Employee>(input);
            await _employeeRepository.InsertAsync(employee);
        }

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

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_DeleteEmployee)]
        public async Task DeleteEmployee(EntityDto input)
        {
            await _employeeRepository.DeleteAsync(input.Id);
        }

        public async Task EditEmployee(EntityDto input)
        {
            var result = await _employeeRepository.FirstOrDefaultAsync(input.Id);
            if (result == null)
            {
                return;
            }
        }

        /*public async Task<EmployeeEditDto> UpdateEmployee(NullableIdDto input)
        {
            EmployeeEditDto employeeEditDto;
            List<NameValue> featureValues;

            if (input.Id.HasValue) //Editing existing edition?
            {
                var employee = await _employeeRepository.FirstOrDefaultAsync(input.Id.Value);
                featureValues = (await _editionManager.GetFeatureValuesAsync(input.Id.Value)).ToList();
                employeeEditDto = ObjectMapper.Map<EmployeeEditDto>(employee);
            }
            else
            {
                editionEditDto = new EditionEditDto();
                featureValues = features.Select(f => new NameValue(f.Name, f.DefaultValue)).ToList();
            }

            var featureDtos = ObjectMapper.Map<List<FlatFeatureDto>>(features).OrderBy(f => f.DisplayName).ToList();

            return new GetEditionEditOutput
            {
                Edition = editionEditDto,
                Features = featureDtos,
                FeatureValues = featureValues.Select(fv => new NameValueDto(fv)).ToList()
            };
        }*/

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
                            Name = e.Name,
                            PhoneNumber = e.PhoneNumber,
                            EmployeeID = e.EmployeeID,
                            Email = e.Email,
                            SSN = e.SSN,
                            Address = e.Address,
                            YearOfBirth = e.YearOfBirth,
                        };

            query = query
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), p => p.Name.Contains(input.Filter) || p.EmployeeID.Contains(input.Filter));
            return query;
        }
    }
}
