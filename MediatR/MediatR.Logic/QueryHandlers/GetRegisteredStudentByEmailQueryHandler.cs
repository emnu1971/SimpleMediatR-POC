using MediatR.Dto;
using MediatR.Logic.Queries;
using MediatR.Logic.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Logic.QueryHandlers
{
    public class GetRegisteredStudentByEmailQueryHandler : IRequestHandler<GetRegisteredStudentByEmailQuery, StudentDto>
    {
        private readonly IStudentRegistrationRepository _studentRegistrationRepository;
        
        public GetRegisteredStudentByEmailQueryHandler(IStudentRegistrationRepository studentRegistrationRepository)
        {
            _studentRegistrationRepository = studentRegistrationRepository;
        }

        public async Task<StudentDto> Handle(GetRegisteredStudentByEmailQuery request, CancellationToken cancellationToken)
        {
            var registeredStudent = await _studentRegistrationRepository.GetRegisteredStudentAsync(request.Email);

            return registeredStudent;
        }
    }
}
