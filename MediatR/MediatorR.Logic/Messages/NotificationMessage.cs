using MediatR;

namespace MediatorR.Logic.Messages
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }


}
