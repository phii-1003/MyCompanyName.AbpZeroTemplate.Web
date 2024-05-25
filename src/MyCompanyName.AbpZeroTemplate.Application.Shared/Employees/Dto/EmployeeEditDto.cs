using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Employees.Dto
{
    public class EmployeeEditDto
    {
        public int? Id { get; set; }

        public const int MaxNameLength = 32;
        public const int PhoneNumberLength = 10;

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public string SSN { get; set; }

        public string EmployeeID { get; set; }

        public string Address { get; set; } = "";

        public uint? YearOfBirth { get; set; } = 2000;

        public uint? Salary { get; set; } = 400;
    }
}
