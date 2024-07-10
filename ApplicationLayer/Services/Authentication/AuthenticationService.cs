using Application.Interface;
using Application.Persistence;
using Domain.Common;
using Domain.Entities;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;

        }
        public ErrorOr <AuthenticationResult> Login(string email, string password)
        {
            //1. Check if user exist
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //2. validate the password
            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
              user,
               token
               );
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastname, string email, string password)
        {
            // Check if user already exist

            if (_userRepository.GetUserByEmail(email) != null)
            {
                return Errors.User.DuplicateEmal;
            }
            //Create a user
            var user = new User
            {
                FirstName = firstName,
                LastName = lastname,
                Email = email,
                Password = password

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
