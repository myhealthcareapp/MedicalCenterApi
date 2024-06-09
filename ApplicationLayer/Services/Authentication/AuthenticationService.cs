using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(), "Ali", "Zafar", email, password);
        }

        public AuthenticationResult Register(string firstName, string lastname, string email, string password)
        {
            return new AuthenticationResult(
                     Guid.NewGuid(), firstName, lastname, email, password);
        }
    }
}
