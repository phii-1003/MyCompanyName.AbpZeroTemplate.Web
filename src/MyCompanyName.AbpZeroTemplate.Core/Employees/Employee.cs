using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Employees
{
    [Table("PbEmployees")]
    public class Employee : FullAuditedEntity
    {
        public const int MaxNameLength = 32;
        public const int PhoneNumberLength = 10;

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [MaxLength(PhoneNumberLength)]
        public virtual string PhoneNumber { get; set;}

        [Required]
        public virtual string SSN { get; set; }

        [Required]
        public virtual string EmployeeID { get; set; }

        public virtual string Address { get; set; }
        
        public virtual uint YearOfBirth { get; set; } = 2000;

    }
}