using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Employees.Dto
{
    public class GetEmployeesInput : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
    }

    public class EmployeeListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string SSN { get; set; }

        public string EmployeeID { get; set; }

        public string Address { get; set; }

        public uint YearOfBirth { get; set; }
    }
}
