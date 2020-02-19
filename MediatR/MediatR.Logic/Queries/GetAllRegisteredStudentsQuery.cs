using MediatR.Domain.Core.Queries;
using MediatR.Dto;
using System.Collections.Generic;

namespace MediatR.Logic.Queries
{
    public class GetAllRegisteredStudentsQuery : IRequest<List<StudentDto>>, IQuery
    {

    }
}
