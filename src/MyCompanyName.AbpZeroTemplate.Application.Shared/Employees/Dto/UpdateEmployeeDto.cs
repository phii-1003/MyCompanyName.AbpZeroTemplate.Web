using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.Employees.Dto
{
    public class UpdateEmployeeDto
    {
        [Required]
        public EmployeeEditDto EmployeeEdit { get; set; }

        [Required]
        public List<NameValueDto> FeatureValues { get; set; }
    }
}
