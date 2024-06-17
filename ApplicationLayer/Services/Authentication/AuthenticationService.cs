using Application.Interface;
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
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) 
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        
        }
        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(), "Ali", "Zafar", email, password);
        }

        public AuthenticationResult Register(string firstName, string lastname, string email, string password)
        {
            // Check if user already exist

            //Create a user

            // Create JWT Token

            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastname);

            return new AuthenticationResult(
                     userId,
                     firstName,
                     lastname,
                     email,
                     token);
        }
    }
}
