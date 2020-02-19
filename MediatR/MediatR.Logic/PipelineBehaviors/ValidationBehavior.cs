using FluentValidation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Logic.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //pre
            
            var context = new ValidationContext(request);
            var failures = _validators
                // execute validation
                .Select(x => x.Validate(context))
                // get possible error result of executed validation
                .SelectMany(x => x.Errors)
                // check if errors are not null
                .Where(x => x != null)
                // create a list of errors
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            
            return next();

            //post
            
        }
    }
}
