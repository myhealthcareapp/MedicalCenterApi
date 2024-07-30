using Application.Interface;
using Application.Persistence;
using Domain.Common;
using Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>

    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
            CancellationToken cancellationToken)
        {
            // Check if user already exist

            if (_userRepository.GetUserByEmail(command.Email) != null)
            {
                return Errors.User.DuplicateEmal;
            }
            //Create a user
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };



            // Create JWT Token

            var token = _jwtTokenGenerator.GenerateToken(user);

            _userRepository.Add(user);

            return new AuthenticationResult(
                     user,
                     token);
        }
    }
}
