using MediatR.Domain.Core.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatR.Logic.Services
{
    public interface IQueryBusMediatorService
    {
        Task<object> SendAsync(IQuery query);
    }
}
