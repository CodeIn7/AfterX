
using AfterX.Contracts.V1;
using AfterX_backend.Contracts.V1.Requests;
using AfterX_backend.Contracts.V1.Responses;
using AfterX_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest registrationRequest)
        {
            var authResponse = await _identityService.RegisterAsync(registrationRequest.Email, registrationRequest.Password, registrationRequest.FirstName, registrationRequest.LastName);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }


            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            var authResponse = await _identityService.LoginAsync(loginRequest.Email, loginRequest.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }


            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }

    }
}
