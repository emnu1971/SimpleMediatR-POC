using MediatR.Dto;
using MediatR.Logic.Queries;
using MediatR.Logic.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Logic.QueryHandlers
{
    public class GetAllRegisteredStudentsQueryHandler : IRequestHandler<GetAllRegisteredStudentsQuery, List<StudentDto>>
    {
        private readonly IStudentRegistrationRepository _studentRegistrationRepository;
        
        public GetAllRegisteredStudentsQueryHandler(IStudentRegistrationRepository studentRegistrationRepository)
        {
            _studentRegistrationRepository = studentRegistrationRepository;
        }
        
        public async Task<List<StudentDto>> Handle(GetAllRegisteredStudentsQuery request, CancellationToken cancellationToken)
        {
            var registeredStudents = await _studentRegistrationRepository.GetRegisteredStudentsAsync();
            return registeredStudents;
        }
    }
}
