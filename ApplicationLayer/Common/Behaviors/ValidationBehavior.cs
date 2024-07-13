using Application.Services.Authentication;
using Application.Services.Authentication.Commands.Register;
using ErrorOr;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class ValidationRegisterCommandBehavior :
        IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public ValidationRegisterCommandBehavior(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request,
            RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(validationResult.IsValid)
            {
                return await next();
            }
            var errors = validationResult.Errors
                .ConvertAll(e => Error.Validation(e.PropertyName, e.ErrorMessage))
                .ToList();
            return errors;
        }
    }
}
