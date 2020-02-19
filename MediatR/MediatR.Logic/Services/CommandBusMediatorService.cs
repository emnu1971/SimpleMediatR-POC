using MediatR.Domain.Core.Commands;
using MediatR.Logic.Messages;
using System;
using System.Threading.Tasks;

namespace MediatR.Logic.Services
{
    public class CommandBusMediatorService : ICommandBusMediatorService
    {
        private readonly IMediator _mediator;

        public CommandBusMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task PublishAsync(ICommand command)
        {
            await _mediator.Publish(new CommandMessage { Command = command });
        }


    }
}
