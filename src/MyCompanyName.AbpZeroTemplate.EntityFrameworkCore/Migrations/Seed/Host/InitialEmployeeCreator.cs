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

        }
    }
}
