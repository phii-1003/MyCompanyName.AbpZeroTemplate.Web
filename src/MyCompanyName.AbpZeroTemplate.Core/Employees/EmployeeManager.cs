using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyCompanyName.AbpZeroTemplate.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Employees
{
    public class EmployeeManager
    {
        private readonly ILocalizationManager _localizationManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        /*public EmployeeManager (
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<EmployeeManager> logger,
            ICacheManager cacheManager,
            IUnitOfWorkManager unitOfWorkManager,
            ILocalizationManager localizationManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            )
        {
            _localizationManager = localizationManager;
            _unitOfWorkManager = unitOfWorkManager;
        }*/

        /*public virtual async Task<Employee> GetEmployeeByIdAsync(long employeeId)
        {
            var employee = await FindByIdAsync(employeeId.ToString());
            if (employee == null)
            {
                throw new ApplicationException("There is no employee with id: " + employeeId);
            }

            return employee;
        }
        public async Task CreateEmployeeAsync (Employee employee )
        {
            await _unitOfWorkManager.WithUnitOfWorkAsync(async () =>
            using ())
        }*/
    }
}
