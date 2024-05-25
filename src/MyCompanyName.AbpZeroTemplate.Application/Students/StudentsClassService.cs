using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Students.Dto;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using MyCompanyName.AbpZeroTemplate.Authorization;

namespace MyCompanyName.AbpZeroTemplate.Students
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_Student)]
    public class StudentsAppService: AbpZeroTemplateAppServiceBase, IStudentsAppService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentsAppService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /*public ListResultDto<EmployeeListDto> GetEmployees(GetEmployeesInput input)
        {
            var employees = _employeeRepository
            .GetAll()
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) ||
                     p.EmployeeID.Contains(input.Filter)
            )
            .OrderBy(p => p.Name)
            .ThenBy(p => p.EmployeeID)
            .ToList();

            return new ListResultDto<EmployeeListDto>(ObjectMapper.Map<List<EmployeeListDto>>(employees));
        }*/

        public async Task<PagedResultDto<StudentListDto>> GetStudents(GetStudentsInput input)
        {
            var query = CreateStudentsQuery(input);

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(p => p.Name)
                .ThenBy(p => p.StudentID)
                .PageBy(input)
                .ToListAsync();

            var studentListDtos = ConvertToStudentListDtos(results);

            return new PagedResultDto<StudentListDto>(resultCount, studentListDtos);
        }
        [AbpAuthorize(AppPermissions.Pages_Tenant_Student_Create)]
        public async Task CreateStudent(StudentCreateDto input)
        {
            var student = ObjectMapper.Map<Student>(input);
            await _studentRepository.InsertAsync(student);
        }
        
        public async Task DeleteStudent(EntityDto input)
        {
            await _studentRepository.DeleteAsync(input.Id);
        }

        public async Task EditStudent(EntityDto input)
        {
            var result = await _studentRepository.FirstOrDefaultAsync(input.Id);
            if (result == null)
            {
                return;
            }
        }

        private List<StudentListDto> ConvertToStudentListDtos(List<Student> results)
        {
            return results.Select(
                result =>
                {
                    var studentListDto = ObjectMapper.Map<StudentListDto>(result);
                    return studentListDto;
                }).ToList();
        }

        private IQueryable<Student> CreateStudentsQuery(GetStudentsInput input)
        {
            var query = from e in _studentRepository.GetAll()
                        select new Student { 
                            StudentID = e.StudentID, 
                            Name = e.Name 
                        };

            query = query
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), p => p.Name.Contains(input.Filter) || p.StudentID.Contains(input.Filter));
            return query;
        }
    }
}
