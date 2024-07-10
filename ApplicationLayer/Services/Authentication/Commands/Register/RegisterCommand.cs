using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Commands.Register
{
    public record RegisterCommand(string FirstName,
        string Lastname,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
