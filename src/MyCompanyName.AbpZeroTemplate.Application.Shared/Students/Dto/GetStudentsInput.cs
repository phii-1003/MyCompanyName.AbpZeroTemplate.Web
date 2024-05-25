using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Students.Dto
{
    public class GetStudentsInput : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
    }

    public class StudentListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public string StudentID { get; set; }
    }
}
