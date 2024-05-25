using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Employees;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialEmployeeCreator
    {
        private readonly AbpZeroTemplateDbContext _dbContext;

        public InitialEmployeeCreator(AbpZeroTemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create()
        {
            var douglas = _dbContext.Employees.FirstOrDefault(p => p.Email == "douglas.adams@fortytwo.com");
            if (douglas == null)
            {
                _dbContext.Employees.Add(
                    new Employee
                    {
                        Name = "DouglasAdam",
                        PhoneNumber = "0375024233",
                        Email = "douglas.adams@fortytwo.com",
                        SSN = "056202207742",
                        EmployeeID = "douglas1",
                        Address ="Dong Hoa",
                        YearOfBirth = 2000,
                        Salary = 400,
                    });
            }
        }
    }
}
