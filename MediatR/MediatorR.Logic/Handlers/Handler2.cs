using MediatorR.Logic.Messages;
using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorR.Logic.Handlers
{
    public class Notifier2 : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from Notifier 2. Message  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }

}
