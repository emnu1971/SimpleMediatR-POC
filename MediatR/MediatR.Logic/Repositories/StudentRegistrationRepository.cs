using MediatR.Dto;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR.Logic.Repositories
{
    public class StudentRegistrationRepository : IStudentRegistrationRepository
    {

        private readonly List<StudentDto> registeredStudents = new List<StudentDto>()
        {
            new StudentDto(){Name = "Emmanuel Nuyttens", Email = "emmanuel.nuyttens@realdolmen.com"},
            new StudentDto(){Name = "Annelies Lenoir", Email = "annelies.lenoir@ronse.com"},
            new StudentDto(){Name = "Pascal Paret", Email = "pascal.paret@hotmail.com"}
        };

        public async Task<StudentDto> GetRegisteredStudentAsync(string email)
        {
            return await Task.FromResult(registeredStudents.Where(s => s.Email == email).FirstOrDefault());
        }

        public async Task<List<StudentDto>> GetRegisteredStudentsAsync()
        {
            return await Task.FromResult(registeredStudents);
        }

        public async Task AddRegisteredStudentAsync(StudentDto registeredStudent)
        {
            await Task.Run(() =>
            {
                registeredStudents.Add(registeredStudent);
            });
        }
    }
}
