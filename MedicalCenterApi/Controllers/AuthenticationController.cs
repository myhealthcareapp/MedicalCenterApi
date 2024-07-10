using Application.Services.Authentication;
using Contracs.Authentication;
using Domain.Common;
using ErrorOr;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenterApi.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr.ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

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
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(request.Email,
              request.Password);
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
