﻿using Application.Services.Authentication;
using Contracs.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenterApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var response = new  AuthenticationResponse(authResult.Id.ToString(), authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token
                );
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email,
              request.Password);

            var response = new AuthenticationResponse(authResult.Id.ToString(),
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token
                );
            return Ok(response);
        }
    }
   
}
