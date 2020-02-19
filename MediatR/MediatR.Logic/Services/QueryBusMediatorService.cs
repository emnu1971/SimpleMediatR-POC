using MediatR.Domain.Core.Queries;
using System.Threading.Tasks;

namespace MediatR.Logic.Services
{
    public class QueryBusMediatorService : IQueryBusMediatorService
    {
        private readonly IMediator _mediator;

        public QueryBusMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<object> SendAsync(IQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
