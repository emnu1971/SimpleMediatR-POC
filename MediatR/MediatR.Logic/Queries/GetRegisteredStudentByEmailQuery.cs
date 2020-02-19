using MediatR.Domain.Core.Queries;
using MediatR.Dto;

namespace MediatR.Logic.Queries
{
    public class GetRegisteredStudentByEmailQuery : IRequest<StudentDto> , IQuery
    {

        public string Email { get; protected set; }

        public GetRegisteredStudentByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
