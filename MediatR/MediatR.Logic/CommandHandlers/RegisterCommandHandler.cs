using MediatR.Logic.Commands;
using MediatR.Logic.Messages;
using MediatR.Logic.Repositories;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Logic
{
    public class RegisterCommandHandler : INotificationHandler<CommandMessage>
    {
        private readonly IStudentRegistrationRepository _studentRegistrationRepository;

        public RegisterCommandHandler(IStudentRegistrationRepository studentRegistrationRepository)
        {
            _studentRegistrationRepository = studentRegistrationRepository;
        }
        public async Task Handle(CommandMessage notification, CancellationToken cancellationToken)
        {
            var newRegistration = (RegisterCommand)notification.Command;

            var result = _studentRegistrationRepository.AddRegisteredStudentAsync(new Dto.StudentDto()
            {
                Name = newRegistration.Name,
                Email = newRegistration.Email
            });

            Debug.WriteLine($"Debugging from {nameof(RegisterCommandHandler)} Message  : {notification.Command.ToString()} ");
            
            await Task.CompletedTask;
        }
    }
}
