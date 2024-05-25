using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Auditing.Dto;
using MyCompanyName.AbpZeroTemplate.Employees.Dto;
using MyCompanyName.AbpZeroTemplate.Students.Dto;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Students
{
    public interface IStudentsAppService : IApplicationService
    {
        //ListResultDto<Dto.StudentListDto> GetStudents(Dto.GetStudentsInput input);
        Task<PagedResultDto<Dto.StudentListDto>> GetStudents(GetStudentsInput input);

        Task CreateStudent(StudentCreateDto input);

        Task EditStudent(EntityDto input);

        Task DeleteStudent(EntityDto input);
    }
}