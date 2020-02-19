using MediatR.Domain.Core.Commands;

namespace MediatR.Logic.Messages
{
    public class CommandMessage : INotification
    {
        public ICommand Command { get; set; }
    }
}
