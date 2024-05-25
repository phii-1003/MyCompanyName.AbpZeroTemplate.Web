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
        public const int MaxEmailLength = 255;

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [MaxLength(PhoneNumberLength)]
        public virtual string PhoneNumber { get; set;}

        [Required]
        [MaxLength(MaxEmailLength)]
        public string Email { get; set; }

        [Required]
        public virtual string SSN { get; set; }

        [Required]
        public virtual string EmployeeID { get; set; }

        public virtual string Address { get; set; }
        
        public virtual uint YearOfBirth { get; set; }

        public virtual uint Salary { get; set; }

        /*public Employee(string name, string phoneNumber, string sSN, string employeeID, string address, uint yearOfBirth = 2000, uint salary = 400)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            SSN = sSN;
            EmployeeID = employeeID;
            Address = address;
            YearOfBirth = yearOfBirth;
            Salary = salary;

            CreationTime = DateTime.Now;
        }*/
    }
}