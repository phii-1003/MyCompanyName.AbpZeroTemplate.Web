using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Employees.Dto
{
    public class EmployeeCreateDto
    {
        [Required]
        [MaxLength(EmployeeConsts.MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(EmployeeConsts.PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(EmployeeConsts.MaxEmailLength)]
        public string Email { get; set; }

        [Required]
        public string SSN { get; set; }

        [Required]
        public string EmployeeID { get; set; }

        public string Address { get; set; } = "";

        public uint? YearOfBirth { get; set; } = 2000;

        public uint? Salary { get; set; } = 400;
    }
}
