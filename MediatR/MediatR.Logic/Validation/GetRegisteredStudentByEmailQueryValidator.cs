using FluentValidation;
using MediatR.Logic.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatR.Logic.Validation
{
    public class GetRegisteredStudentByEmailQueryValidator : AbstractValidator<GetRegisteredStudentByEmailQuery>
    {
        public GetRegisteredStudentByEmailQueryValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage($"THE EMAIL SHOULD NOT BE EMPTY WHEN QUERYING BY EMAIL !!!");
        }
    }
}
