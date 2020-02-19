namespace MediatR.Logic.Messages
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}
