using MediatR.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatR.Logic.Repositories
{
    public interface IStudentRegistrationRepository
    {
        Task<List<StudentDto>> GetRegisteredStudentsAsync();

        Task<StudentDto> GetRegisteredStudentAsync(string email);

        Task AddRegisteredStudentAsync(StudentDto registeredStudent);
    }
}
