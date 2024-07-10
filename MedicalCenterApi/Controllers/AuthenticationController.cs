﻿using Application.Services.Authentication;
using Application.Services.Authentication.Commands.Register;
using Application.Services.Authentication.Queries.Login;
using Contracs.Authentication;
using Domain.Common;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenterApi.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        private readonly ISender _mediator;
        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task <IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

            ErrorOr.ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                    authResult => Ok(MapAuthResult(authResult)),
                    errors => Problem(errors)
                    );

        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse
                (
                authResult.user.Id.ToString(),
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
                );
        }

        [HttpPost("login")]
        public async Task <IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
            if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized,
                        title: authResult.FirstError.Description
                    );
            }
            return authResult.Match(
                    authResult => Ok(MapAuthResult(authResult)),
                    errors => Problem(errors)
                    );

        }
    }

}
