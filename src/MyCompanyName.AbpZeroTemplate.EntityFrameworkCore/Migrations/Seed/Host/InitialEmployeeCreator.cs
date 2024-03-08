using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var douglas = _dbContext.Employees.FirstOrDefault((p) => p.SSN == "");
            if (douglas == null)
            {
                _dbContext.Employees.Add(
                    new Employees.Employee
                    {
                        Name = "Bui Hoang Phi",
                        PhoneNumber = "0376024230",
                        SSN = "000410003213",
                        EmployeeID = "2000000"
                    });
            }

            var piii = _dbContext.Employees.FirstOrDefault((p) => p.SSN == "");
            if (piii == null)
            {
                _dbContext.Employees.Add(
                    new Employees.Employee
                    {
                        Name = "Bui Hoang Phii",
                        PhoneNumber = "0376024231",
                        SSN = "000410003211",
                        EmployeeID = "2000001"
                    });
            }

        }
    }
}
