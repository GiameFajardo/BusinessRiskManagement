using BusinessRiskManagement.Requests;
using BusinessRiskManagement.Responses;
using Core.Application.Contracts.Services;
//using Microsoft.AspNetCore.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessRiskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public readonly UserManager<IdentityUser> _userManager;

        public readonly SignInManager<IdentityUser> _signInManager;

        public IdentityController(IIdentityService identityService
            )
        {
            this._identityService = identityService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResult = await _identityService.Register(request.Email, request.Password);
            if (!authResult.Sussess)
            {
                return BadRequest(new AuthorizationFailedResponse
                {
                    Errors = authResult.Errors
                });
            }
            return Ok(new AuthorizationSussessResponse
            {
                Token = authResult.Token
            });
        }
    }
            
}
