﻿using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
        ErrorOr<AuthenticationResult> Register(string firstName, string lastname, string email, string password);


    }
}
