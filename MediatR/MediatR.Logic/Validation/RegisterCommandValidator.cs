using FluentValidation;
using MediatR.Logic.Commands;

namespace MediatR.Logic.Validation
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
