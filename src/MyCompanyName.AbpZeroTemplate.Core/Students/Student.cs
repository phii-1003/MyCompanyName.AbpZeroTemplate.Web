using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Students
{
    [Table("PbStudents")]
    public class Student : FullAuditedEntity
    {
        public const int MaxNameLength = 32;
        public const int PhoneNumberLength = 10;

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [MaxLength(PhoneNumberLength)]
        public virtual string ParentPhoneNumber { get; set;}

        [Required]
        public virtual string StudentID { get; set; }

        public virtual string Address { get; set; }
        
        public virtual uint YearOfBirth { get; set; } = 2000;

        public virtual string Class { get; set; } = "None";

    }
}