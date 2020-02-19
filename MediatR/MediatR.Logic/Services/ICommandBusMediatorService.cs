using MediatR.Domain.Core.Commands;
using System.Threading.Tasks;

namespace MediatR.Logic.Services
{
    public interface ICommandBusMediatorService
    {
        Task PublishAsync(ICommand command);
    }
}
