
using AfterX.Contracts.V1;
using AfterX_backend.Contracts.V1.Requests;
using AfterX_backend.Contracts.V1.Responses;
using AfterX_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfterX;

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
            Userattribue userattribue = new Userattribue
            {
                Firstname = registrationRequest.Firstname,
                Lastname = registrationRequest.Lastname,
                Gender = registrationRequest.Gender,
                Yearofbirth = registrationRequest.Yearofbirth,
                Telephone = registrationRequest.Telephone,
            };
            User user = new User
            {
                UserName = registrationRequest.Email, 
                Email = registrationRequest.Email,
                Userattribue = userattribue,
            };
            var authResponse = await _identityService.RegisterAsync(user, registrationRequest.Password, registrationRequest.RoleName);

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
