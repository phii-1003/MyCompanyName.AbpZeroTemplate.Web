using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Students.Dto
{
    public class StudentCreateDto
    {
        public const int MaxNameLength = 32;
        public const int PhoneNumberLength = 10;

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(PhoneNumberLength)]
        public string ParentPhoneNumber { get; set; }

        [Required]
        public string StudentID { get; set; }

        public string Address { get; set; }

        public uint YearOfBirth { get; set; } = 2000;

        public string Class { get; set; } = "None";
    }
}
